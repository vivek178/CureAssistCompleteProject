using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;
using pharmacy_portal_backend.Entities;
using System.Linq;
using System;
using Newtonsoft.Json;
using pharmacy_portal_backend.DataAccess;

namespace pharmacy_portal_backend.Hubs
{  
    public class PharmacyNotificationHub : Hub
    {

        private static Dictionary<string, List<Quotation>> prescriptionQuotationsMap;
        private static List<PrescriptionOrderRequest> orderRequest = new List<PrescriptionOrderRequest>();
        private static Dictionary<string, string> pharmacyClientMapping;
        public static Dictionary<string, List<string>> pharmacyConnectionMapping;
        //private readonly PharmacyDbContext pharmacyContext;
        //public PharmacyNotificationHub(PharmacyDbContext pharmacyDb)
        //{
        //    this.pharmacyContext = pharmacyDb;
        //}


        public PharmacyNotificationHub()
        {
            if (prescriptionQuotationsMap == null) 
            {
                prescriptionQuotationsMap = new Dictionary<string, List<Quotation>>();
            }
            if (pharmacyClientMapping == null)
            {
                pharmacyClientMapping = new Dictionary<string, string>();
            }
            if (pharmacyConnectionMapping == null)
            {
                pharmacyConnectionMapping = new Dictionary<string, List<string>>();
            }
        }

        public void Initialize(string pharmacyPincode)
        {
            Console.WriteLine(pharmacyPincode, "got pincode");
            if (!pharmacyConnectionMapping.ContainsKey(pharmacyPincode))
            {
                pharmacyConnectionMapping.Add(pharmacyPincode, new List<string>());
            }
            pharmacyConnectionMapping[pharmacyPincode].Add(Context.ConnectionId);

        }

        public async Task SendNotification(PrescriptionOrderRequest prescription)
        {
            Console.WriteLine(prescription);
            await Clients.Clients(pharmacyConnectionMapping[prescription.Pincode]).SendAsync("ReceiveQuotationRequest", prescription);
            //await Clients.All.SendAsync("ReceiveQuotationRequest", prescription);
            if (!prescriptionQuotationsMap.ContainsKey(prescription.PrescriptionId))
            {
                prescriptionQuotationsMap.Add(prescription.PrescriptionId, new List<Quotation>());
                orderRequest.Add(prescription);
            }
        }

        // Patients Invokes this function
        public async Task GetQuotation(string prescriptionId)
        {
            Console.WriteLine("Received the Get Quotation");
            // Find the minimum and send to the client.
            Quotation prescriptionQuotationWithLowestPrice = new Quotation();
            try{
            var prescriptionQuotations = prescriptionQuotationsMap[prescriptionId];
            var SortedListAccordingToTotalCost = prescriptionQuotations.OrderBy( o => o.TotalCost).ToList();
             //var prescriptionQuotationWithLowestPrice = SortedListAccrdingToTotalCost.ElementAt(0);
            prescriptionQuotationWithLowestPrice = SortedListAccordingToTotalCost.FirstOrDefault();
            //await Clients.Caller.SendAsync("Quotation", prescriptionQuotationWithLowestPrice);
            await Clients.Caller.SendAsync("SelectedQuotation", prescriptionQuotationWithLowestPrice);
            Console.WriteLine(JsonConvert.SerializeObject(prescriptionQuotationWithLowestPrice));
            foreach(var prescription in orderRequest)
            {
                if (prescriptionId == prescription.PrescriptionId)
                {
                    var clientId = pharmacyClientMapping[prescriptionQuotationWithLowestPrice.PharmacyId];
                    await Clients.Client(clientId).SendAsync("PatientDetails", prescription);
                     Console.WriteLine(JsonConvert.SerializeObject(prescription));
                        orderRequest.Remove(prescription);
                    }
                   
                }
                prescriptionQuotationsMap.Remove(prescriptionId);


            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message, "getting error here");
            }
        }

        // Pharamcist Invokes this function
        public void ReceiveQuotation(string prescriptionId, Quotation quotation)
        {
            var prescriptionQuotation = prescriptionQuotationsMap[prescriptionId];
            if (prescriptionQuotation != null)
            {
                Console.WriteLine("getting data");
                Console.WriteLine(JsonConvert.SerializeObject(quotation));
                prescriptionQuotationsMap[prescriptionId].Add(quotation);
            }
            if (pharmacyClientMapping.ContainsKey(quotation.PharmacyId))
            {
                pharmacyClientMapping[quotation.PharmacyId] = Context.ConnectionId;
            }
            else
            {
                pharmacyClientMapping.Add(quotation.PharmacyId, Context.ConnectionId);
            }
        }

    }




}

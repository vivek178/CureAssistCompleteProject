using System;
using pharmacy_portal_backend.Entities;
using Microsoft.AspNetCore.SignalR.Client;
using System.Threading.Tasks;
using Newtonsoft.Json;
using pharmacy_portal_backend.Hubs;

namespace pharmacy_portal_backend.BusinessLayer
{
    public class PrescriptionOrderRequestNotificationService: IPrescriptionOrderRequestNotificationService
    {
        HubConnection connection;

        public PrescriptionOrderRequestNotificationService()
        {
            connection = new HubConnectionBuilder().WithUrl("http://pharmacy-api.cureassist.cgi-wave7.stackroute.io/notifications").Build();
            connection.On<PrescriptionOrderRequest>("OrderReceived", order => {
                Console.WriteLine(order);
            });
           connection.Closed += async (error) =>
            {
                Console.WriteLine(error.Message);
                await StartConnectionAsync();
            };
        }

            public async Task SendOrderNotificationAsync(PrescriptionOrderRequest currentOrderRequest)
        {
            if (connection.State == HubConnectionState.Disconnected)
            {
                await StartConnectionAsync();
            }
            Console.WriteLine("Printing Serialized Object");
            Console.WriteLine(JsonConvert.SerializeObject(currentOrderRequest));
            Console.WriteLine("Sending Notification");
            await connection.InvokeAsync("SendNotification", currentOrderRequest);
        }


        public async Task StartConnectionAsync()
        {
            await connection.StartAsync();
        }
    }
}
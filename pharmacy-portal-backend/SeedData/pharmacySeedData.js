// JavaScript source code
conn = new Mongo();
db = conn.getDB("PharmacyDb");
const pharmacyDetails = [
{
        "PrescriptionId": "40000",
            "PrescriptionDate": "2019-01-01",
                "PatientId": "1111",
                    "PatientName": "sindhu",
                        "DoctorName": "Annapurna",
                            "PatientPhoneNumber": "+91 931462-3548",
                                "DoctorPhoneNumber": "+91 910596-3726",
                                    "Symptoms": ["fever", "cold"],
                                        "Remarks": "Complete Bedrest",
                                            "CurrentLocation": "Bengaluru",
                                                "PrescribedMedicines":
    [{

        "MedicineName": "dolo650",
            "PrescribedDosage": "650mg",
                "PrescribedTimings": [
                    "Morning",
                    "afternoon",
                    "evening"
                ],
                    "Quantity": "one sheet",


                        "PrescribedDays": "1"

    }]
},

{
        "PrescriptionId": "40001",
            "PrescriptionDate": "2019-02-01",
                "PatientId": "2222",
                    "PatientName": "Annapurna",
                        "DoctorName": "sindhu",
                            "PatientPhoneNumber": "+91 931462-3548",
                                "DoctorPhoneNumber": "+91 910596-3726",
                                    "Symptoms": ["cold"],
                                        "Remarks": "stay away from Icecream",
                                            "PrescribedMedicines":
   [ {

        "MedicineName": "sumocold500",
            "PrescribedDosage": "500mg",
                "PrescribedTimings": [
                    "Morning",
                    "afternoon"

                ],
                    "Quantity": "1 sheet",

                        "PrescribedDays": "2"

    }]
    }]
db.PharmacyCurrentOrderDb.insertMany(pharmacyDetails);

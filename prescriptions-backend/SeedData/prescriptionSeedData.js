conn = new Mongo();
db = conn.getDB("prescriptions5");
const prescriptiondetails =
    [
        {

            "prescriptionDate": "2019-01-01",
            "patientId": "1111",
            "patientName": "sindhu",
            "doctorName": "Annapurna",
            "patientPhoneNumber": "+91 931462-3548",
            "doctorphoneNumber": "+91 910596-3726",
            "symptoms": ["fever", "cold"],
            "remarks": "Complete Bedrest",
            "allPrescribedMedicines": 
            [
                {
                    "medicineName": "dolo650",
                    "prescribedDosage": "650mg",
                    "prescribedTimings": [
                        "Morning",
                        "afternoon",
                        "evening"
                    ],
                    "prescribedDays": "1"
                },
                {
                    "medicineName": "dolo650",
                    "prescribedDosage": "650mg",
                    "prescribedTimings": [
                        "Morning",
                        "afternoon",
                        "evening"
                    ],
                    "prescribedDays": "1"
                }
            ]
        },
        {
            
            "prescriptionDate": "2019-02-01",
            "patientId": "1111",
            "patientName": "sindhu",
            "doctorName": "Annapurna",
            "patientPhoneNumber": "+91 931462-3548",
            "doctorphoneNumber": "+91 910596-3726",
            "symptoms": ["cold"],
            "remarks": "stay away from Icecream",
            "allPrescribedMedicines": 
            [
                {
                    "medicineName": "sumocold500",
                    "prescribedDosage": "500mg",
                    "prescribedTimings": [
                        "Morning",
                        "afternoon"
                    ],
                    "prescribedDays":"2"
                }
            ]
        },
        {
            
            "prescriptionDate": "2019-04-01",
            "patientId": "4444",
            "patientName": "vinnela",
            "doctorName": "sonali",
            "patientPhoneNumber": "+91 931462-3548",
            "doctorphoneNumber": "+91 910596-3726",
            "symptoms": ["cough"],
            "remarks": "stay away from icecream",
            "allPrescribedMedicines": 
            [
                {
                    "medicineName": "hycodone",
                    "prescribedDosage": "5ml",
                    "prescribedTimings": [
                        "Morning",
                        "evening"
                    ],
                    "prescribedDays": "7"
                }
            ]
        },
        {
            
            "prescriptionDate": "2019-04-01",
            "patientId": "5555",
            "patientName": "sindhu",
            "doctorName": "sonali",
            "patientPhoneNumber": "+91 931462-3548",
            "doctorphoneNumber": "+91 910596-3726",
            "symptoms": ["cough"],
            "remarks": "stay away from icecream",
            "allPrescribedMedicines": 
            [
                {
                    "medicineName": "hycodone",
                    "prescribedDosage": "5ml",
                    "prescribedTimings": [
                        "Morning",
                        "evening"
                    ],
                    "prescribedDays": "7"
                }
            ]
        },
        {
            
            "prescriptionDate": "2019-04-01",
            "patientId": "5555",
            "patientName": "sindhu",
            "doctorName": "sonali",
            "patientPhoneNumber": "+91 931462-3548",
            "doctorphoneNumber": "+91 910596-3726",
            "symptoms": ["headache"],
            "remarks": "take bedrest",
            "allPrescribedMedicines": 
            [
                {
                    "medicineName": "hycodone",
                    "prescribedDosage": "5ml",
                    "prescribedTimings": [
                        "Morning",
                        "evening"
                    ],
                    "prescribedDays": "7"
                }
            ]
        },

        {

            "prescriptionDate": "2019-01-01",
            "patientId": "6666",
            "patientName": "Hamza",
            "doctorName": "vivek",
            "patientPhoneNumber": "+91 931462-3548",
            "doctorphoneNumber": "+91 910596-3726",
            "symptoms": ["fever", "cold"],
            "remarks": "Complete Bedrest",
            "allPrescribedMedicines": 
            [
                {
                    "medicineName": "dolo650",
                    "prescribedDosage": "650mg",
                    "prescribedTimings": [
                        "Morning",
                        "afternoon",
                        "evening"
                    ],
                    "prescribedDays": "1"
                },
                {
                    "medicineName": "dolo650",
                    "prescribedDosage": "650mg",
                    "prescribedTimings": [
                        "Morning",
                        "afternoon",
                        "evening"
                    ],
                    "prescribedDays": "1"
                }
            ]
        },

        {
            
            "prescriptionDate": "2019-04-01",
            "patientId": "6666",
            "patientName": "Hamza",
            "doctorName": "vivek",
            "patientPhoneNumber": "+91 931462-3548",
            "doctorphoneNumber": "+91 910596-3726",
            "symptoms": ["headache"],
            "remarks": "take bedrest",
            "allPrescribedMedicines": 
            [
                {
                    "medicineName": "naflon",
                    "prescribedDosage": "500mg",
                    "prescribedTimings": [
                        "Morning",
                        "evening"
                    ],
                    "prescribedDays": "7"
                }
            ]
        }




    ]
db.prescriptionRepo.insertMany(prescriptiondetails);
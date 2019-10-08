connection = new Mongo();
database = connection.getDB("DiagnosisCenters-Doctors-Database");

const doctorsDetails = [
  {
    "ts": [],
    //"doctorId": "5d80f31542fd782014fb946e",
    "doctorFirstName": "John",
    "doctorLastName": "Doe",
    "doctorEmail": "john.doe@gmail.com",
    "doctorPhoneNumber": "9988665533",
    "doctorRegNum": "REG309876",
    "doctorSpecialization": "General Surgeon",
    "doctorExperience": 8,
    "doctorCity": "Bangalore",
    "doctorAddress": "Jaya Nagar",
    "pincode": "566004",
    "doctorSlots": [
      {
        //"slotId": "5d80f46942fd782014fb9471",
        "doctorId": "5d80f31542fd782014fb946e",
        // "slotDate": "22/09/2019",
        "slotStartTime": "09:45 AM",
        "slotEndTime": "11:00 AM",
        "slotCapacity": 6
    },
    {
        //"slotId": "5d80f48642fd782014fb9472",
        "doctorId": "5d80f31542fd782014fb946e",
        // "slotDate": "22/09/2019",
        "slotStartTime": "11:45 AM",
        "slotEndTime": "02:30 PM",
        "slotCapacity": 7
    }
    ]
},
{
    "ts": [],
    //"doctorId": "5d80f38d42fd782014fb946f",
    "doctorFirstName": "Maria",
    "doctorLastName": "King",
    "doctorEmail": "maria.king@doctor.com",
    "doctorPhoneNumber": "8845339901",
    "doctorRegNum": "REG458723",
    "doctorSpecialization": "Cardilogist",
    "doctorExperience": 12,
    "doctorCity": "Hyderabad",
    "doctorAddress": "Alwynn Street",
    "pincode": "500042",
    "doctorSlots": [
      {
        //"slotId": "5d80f4e942fd782014fb9473",
        "doctorId": "5d80f38d42fd782014fb946f",
        // "slotDate": "22/09/2019",
        "slotStartTime": "11:45 AM",
        "slotEndTime": "02:30 PM",
        "slotCapacity": 7
    },
    {
        //"slotId": "5d80f50342fd782014fb9474",
        "doctorId": "5d80f38d42fd782014fb946f",
        // "slotDate": "22/09/2019",
        "slotStartTime": "04:45 PM",
        "slotEndTime": "07:45 PM",
        "slotCapacity": 10
    }
    ]
},
{
    "ts": [],
    //"doctorId": "5d80f3d642fd782014fb9470",
    "doctorFirstName": "Charlie",
    "doctorLastName": "Rush",
    "doctorEmail": "charlie.rush@doctor.com",
    "doctorPhoneNumber": "7745600231",
    "doctorRegNum": "REG560324",
    "doctorSpecialization": "Pediatrician",
    "doctorExperience": 9,
    "doctorCity": "Chennai",
    "doctorAddress": "T Nagar",
    "pincode": "600342",
    "doctorSlots": [
      {
        //"slotId": "5d80f54342fd782014fb9475",
        "doctorId": "5d80f3d642fd782014fb9470",
        // "slotDate": "22/09/2019",
        "slotStartTime": "10:30 AM",
        "slotEndTime": "12:45 PM",
        "slotCapacity": 10
    },
    {
        //"slotId": "5d80f55e42fd782014fb9476",
        "doctorId": "5d80f3d642fd782014fb9470",
        // "slotDate": "22/09/2019",
        "slotStartTime": "01:30 PM",
        "slotEndTime": "03:45 PM",
        "slotCapacity": 10
    }
    ]
}
];

const diagnosticCentersDetails = [
    {
      "ts": [],
      //"diagnosticCenterId": "5d80ed5242fd782014fb9465",
    "diagnosticCenterName": "Cure Assist Diagnostic Center",
    "diagnosticCenterEmail": "cure.assist@diagcen.com",
    "diagnosticCenterPhone": "9987764432",
    "diagnosticCenterCity": "Bangalore",
    "diagnosticCenterRegNum": "REG133456",
    "diagnosticCenterAddress": "4th Cross, Churchill Street",
    "pincode": "560089",
    "testsConducted": "ECG,Blood Sample Test",
    "diagnosticCenterSlots": [
        {
            //"slotId": "5d80eeed42fd782014fb9468",
            "diagnosticCenterId": "5d80ed5242fd782014fb9465",
            "testConductedInSlot": "ECG",
            // "slotDate": "22/09/2019",
            "slotStartTime": "10:30 AM",
            "slotEndTime": "11:45 AM",
            "slotCapacity": 10
        },
        {
            //"slotId": "5d80ef0a42fd782014fb9469",
            "diagnosticCenterId": "5d80ed5242fd782014fb9465",
            "testConductedInSlot": "Blood Sample Test",
            // "slotDate": "22/09/2019",
            "slotStartTime": "10:30 AM",
            "slotEndTime": "12:30 AM",
            "slotCapacity": 20
        }
    ]
},
    {
      "ts": [],
     // "diagnosticCenterId": "5d80ed9442fd782014fb9466",
      "diagnosticCenterName": "Acura Diagnostic Center",
      "diagnosticCenterEmail": "acura@diagcen.com",
      "diagnosticCenterPhone": "9987764432",
      "diagnosticCenterCity": "Hyderabad",
      "diagnosticCenterRegNum": "REG143557",
      "diagnosticCenterAddress": "Indira Nagar",
      "pincode": "500024",
      "testsConducted": "Blood Sample Test,X Ray",
      "diagnosticCenterSlots": [
          {
              //"slotId": "5d80efac42fd782014fb946a",
              "diagnosticCenterId": "5d80ed9442fd782014fb9466",
              "testConductedInSlot": "Blood Sample Test",
              // "slotDate": "22/09/2019",
              "slotStartTime": "10:30 AM",
              "slotEndTime": "12:30 AM",
              "slotCapacity": 20
          },
          {
              //"slotId": "5d80efc842fd782014fb946b",
              "diagnosticCenterId": "5d80ed9442fd782014fb9466",
              "testConductedInSlot": "X Ray",
              // "slotDate": "22/09/2019",
              "slotStartTime": "12:30 PM",
              "slotEndTime": "2:30 PM",
              "slotCapacity": 8
          }
      ]
  },
    {
      "ts": [],
      //"diagnosticCenterId": "5d80edfa42fd782014fb9467",
    "diagnosticCenterName": "Vision Diagnostic Center",
    "diagnosticCenterEmail": "vision@diagcen.com",
    "diagnosticCenterPhone": "9987764432",
    "diagnosticCenterCity": "Mumbai",
    "diagnosticCenterRegNum": "REG145657",
    "diagnosticCenterAddress": "Andheri",
    "pincode": "400230",
    "testsConducted": "Radiation Therapy,MRI Scan",
    "diagnosticCenterSlots": [
        {
            //"slotId": "5d80f02b42fd782014fb946c",
            "diagnosticCenterId": "5d80edfa42fd782014fb9467",
            "testConductedInSlot": "Radiation Therapy",
            // "slotDate": "22/09/2019",
            "slotStartTime": "12:30 PM",
            "slotEndTime": "2:30 PM",
            "slotCapacity": 8
        },
        {
            //"slotId": "5d80f04642fd782014fb946d",
            "diagnosticCenterId": "5d80edfa42fd782014fb9467",
            "testConductedInSlot": "MRI Scan",
            // "slotDate": "22/09/2019",
            "slotStartTime": "10:30 AM",
            "slotEndTime": "12:30 PM",
            "slotCapacity": 5
        }
    ]
}
];


database.DoctorsDatabase.insertMany(doctorsDetails);

database.DiagnosisCentersDatabase.insertMany(diagnosticCentersDetails);


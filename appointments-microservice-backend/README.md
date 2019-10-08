# Appointments

<!-- Doctor -->
```json
{
    userId: "DoctorsUserID",
    date: "10/9/2019",
    slots: [
        {
            timeSlot: {
                startTime: "9.30",
                endTime: "9.45",
            },
            capacity: "2",
            attendees: [
                "PatientId1",
                "PatientId2",
            ]
        },
        {
            
        }
    ]
}
```

```json
{
    userId: "doctorId/diagnosticId",
    attendeeId: "patientId",
    date: "",
    startTime: "",
    endTime: "",
},
{
    userId: "doctorId/diagnosticId",
    attendeeId: "patientId",
    date: "",
    startTime: "",
    endTime: "",
},
{
    userId: "doctorId/diagnosticId",
    attendeeId: "patientId",
    date: "",
    startTime: "",
    endTime: "",
},
{
    userId: "doctorId/diagnosticId",
    attendeeId: "patientId",
    date: "",
    startTime: "",
    endTime: "",
}
```

<!-- Doctor -->
```json
{
    userId: "DoctorsUserID",
    date: "10/9/2019",
    slots: [
        {
            timeSlot: {
                startTime: "9.30",
                endTime: "9.45",
            },
            capacity: "2",
            attendees: [
                {
                    "PatientId1": "",
                    "symptom": ["fever","cold"]
                },
                {
                    "PatientId2": "",
                    "symptom": ["fever"]
                }
            ]
        },
        {
            
        }
    ]
}
```
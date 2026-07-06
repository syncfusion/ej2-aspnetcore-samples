using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ2CoreSampleBrowser.Models
{
    
    public class AppointmentDetails
    {
        public AppointmentDetails() { }

        public AppointmentDetails(string apptID, DateTime appointmentTime, string patient, string doctor,
            string room, string type, string status, double fee, string notes)
        {
            this.ApptID = apptID;
            this.AppointmentTime = appointmentTime;
            this.Patient = patient;
            this.Doctor = doctor;
            this.Room = room;
            this.Type = type;
            this.Status = status;
            this.Fee = fee;
            this.Notes = notes;
        }

        public static List<AppointmentDetails> GetAllRecords()
        {
            List<AppointmentDetails> data = new List<AppointmentDetails>()
            {
                new AppointmentDetails("APT-1001", new DateTime(2025,12,10,11,30,0), "John Miller", "Dr. Martinez", "R7", "Consultation", "Booked", 50, "Requires follow-up in 2 weeks"),
                new AppointmentDetails("APT-1002", new DateTime(2025,12,10,12,0,0), "Emma Wilson", "Dr. Smitha", "R1", "Follow-up", "Canceled", 75, "Prescribed medication after evaluation"),
                new AppointmentDetails("APT-1003", new DateTime(2025,12,10,14,0,0), "Liam Davis", "Dr. Garcia", "R6", "Emergency", "Completed", 70, "Vitals are stable and normal"),
                new AppointmentDetails("APT-1004", new DateTime(2025,12,10,14,30,0), "Olivia Brown", "Dr. Brianna", "R4", "Routine Check", "Pending", 150, "Lab test recommended for further diagnosis"),
                new AppointmentDetails("APT-1005", new DateTime(2025,12,11,11,30,0), "Noah Taylor", "Dr. Davis", "R8", "Lab Test", "Booked", 200, "Under observation for short duration"),
                new AppointmentDetails("APT-1006", new DateTime(2025,12,11,12,0,0), "Ava Anderson", "Dr. Johnson", "R2", "Consultation", "Completed", 125, "Follow-up completed successfully"),
                new AppointmentDetails("APT-1007", new DateTime(2025,12,11,14,0,0), "James Thomas", "Dr. Williams", "R3", "Emergency", "Booked", 300, "Patient condition improving steadily"),
                new AppointmentDetails("APT-1008", new DateTime(2025,12,11,15,0,0), "Sophia Jackson", "Dr. Smitha", "R1", "Routine Check", "Pending", 120, "Initial diagnosis recorded"),
                new AppointmentDetails("APT-1009", new DateTime(2025,12,12,11,30,0), "Lucas White", "Dr. Brianna", "R4", "Follow-up", "Completed", 180, "Further evaluation needed"),
                new AppointmentDetails("APT-1010", new DateTime(2025,12,12,12,0,0), "Mia Harris", "Dr. Davis", "R8", "Consultation", "Booked", 220, "Routine check completed"),
                new AppointmentDetails("APT-1011", new DateTime(2025,12,12,14,0,0), "Ethan Martin", "Dr. Garcia", "R6", "Lab Test", "Pending", 90, "Medication adjusted"),
                new AppointmentDetails("APT-1012", new DateTime(2025,12,12,15,30,0), "Amelia Thompson", "Dr. Martinez", "R7", "Emergency", "Canceled", 160, "Diet plan suggested"),
                new AppointmentDetails("APT-1013", new DateTime(2025,12,13,11,30,0), "Daniel Garcia", "Dr. Johnson", "R2", "Consultation", "Booked", 210, "Symptoms reduced"),
                new AppointmentDetails("APT-1014", new DateTime(2025,12,13,12,0,0), "Harper Martinez", "Dr. Williams", "R3", "Follow-up", "Completed", 260, "Referred to specialist"),
                new AppointmentDetails("APT-1015", new DateTime(2025,12,13,14,30,0), "Henry Robinson", "Dr. Smitha", "R1", "Routine Check", "Pending", 80, "Scheduled for scan"),
                new AppointmentDetails("APT-1016", new DateTime(2025,12,13,16,0,0), "Ella Clark", "Dr. Joanna", "R5", "Lab Test", "Booked", 140, "Test results reviewed"),
                new AppointmentDetails("APT-1017", new DateTime(2025,12,10,15,0,0), "Alexander Rodriguez", "Dr. Garcia", "R6", "Emergency", "Completed", 170, "Condition stable"),
                new AppointmentDetails("APT-1018", new DateTime(2025,12,10,16,30,0), "Grace Lewis", "Dr. Martinez", "R7", "Consultation", "Booked", 230, "Recovery in progress"),
                new AppointmentDetails("APT-1019", new DateTime(2025,12,10,17,30,0), "Michael Lee", "Dr. Davis", "R8", "Follow-up", "Pending", 270, "Minor symptoms present"),
                new AppointmentDetails("APT-1020", new DateTime(2025,12,11,15,30,0), "Chloe Walker", "Dr. Smitha", "R1", "Routine Check", "Canceled", 60, "Follow-up next month"),
                new AppointmentDetails("APT-1021", new DateTime(2025,12,11,16,30,0), "Benjamin Hall", "Dr. Brianna", "R4", "Lab Test", "Booked", 110, "Observation continued"),
                new AppointmentDetails("APT-1022", new DateTime(2025,12,11,17,30,0), "Zoe Allen", "Dr. Johnson", "R2", "Consultation", "Completed", 190, "Treatment ongoing"),
                new AppointmentDetails("APT-1023", new DateTime(2025,12,12,16,30,0), "Jacob Young", "Dr. Williams", "R3", "Emergency", "Pending", 240, "Improvement noted"),
                new AppointmentDetails("APT-1024", new DateTime(2025,12,12,17,30,0), "Lily King", "Dr. Garcia", "R6", "Routine Check", "Booked", 280, "Discharge planned"),
                new AppointmentDetails("APT-1025", new DateTime(2025,12,13,15,0,0), "Logan Wright", "Dr. Martinez", "R7", "Follow-up", "Completed", 130, "Checkup completed"),
                new AppointmentDetails("APT-1026", new DateTime(2025,12,13,16,30,0), "Aria Scott", "Dr. Smitha", "R1", "Consultation", "Booked", 155, "Additional tests advised"),
                new AppointmentDetails("APT-1027", new DateTime(2025,12,13,17,30,0), "David Green", "Dr. Brianna", "R4", "Lab Test", "Pending", 205, "Rest recommended"),
                new AppointmentDetails("APT-1028", new DateTime(2025,12,12,15,0,0), "Scarlett Adams", "Dr. Davis", "R8", "Emergency", "Canceled", 225, "Fluid intake increased"),
                new AppointmentDetails("APT-1029", new DateTime(2025,12,10,16,0,0), "Joseph Baker", "Dr. Johnson", "R2", "Routine Check", "Booked", 265, "Short-term medication given"),
                new AppointmentDetails("APT-1030", new DateTime(2025,12,10,17,0,0), "Layla Nelson", "Dr. Williams", "R3", "Follow-up", "Completed", 295, "Monitoring advised")
            };
            return data;
        }
        public string ApptID { get; set; }
        public DateTime AppointmentTime { get; set; }
        public string Patient { get; set; }
        public string Doctor { get; set; }
        public string Room { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public double Fee { get; set; }
        public string Notes { get; set; }
    }

}
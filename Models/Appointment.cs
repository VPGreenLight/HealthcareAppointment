namespace HealthcareAppointment.Models
{
    public partial class Appointment
    {
        public string Id { get; set; } = null!;
        public string PatientId { get; set; } = null!;
        public string DoctorId { get; set; } = null!;
        public DateTime Date { get; set; }
        public string Status { get; set; } = null!;

        public virtual User Patient { get; set; } = null!;
    }
}

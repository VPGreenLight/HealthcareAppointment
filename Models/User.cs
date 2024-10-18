namespace HealthcareAppointment.Models
{
    public partial class User
    {
        public User()
        {
            Appointments = new HashSet<Appointment>();
        }

        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Password { get; set; } = null!;
        public int Role { get; set; }
        public string Specialization { get; set; } = null!;

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}

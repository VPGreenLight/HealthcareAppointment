using HealthcareAppointment.Models;

namespace HealthcareAppointment.Bussiness
{
    public interface IAppointmentService
    {
        List<Appointment> GetList();

        Appointment Create(Appointment request);

        Appointment Update(Appointment request);

        bool Delete(string id);
    }
    public class AppointmentService : IAppointmentService
    {
        HealthcareAppointmentContext _context;
        public AppointmentService(HealthcareAppointmentContext context)
        {
            _context = context;
        }
        public List<Appointment> GetList() 
        { 
            return _context.Appointments.ToList(); 
        }

        public Appointment Create(Appointment request)
        {
            var appointment = _context.Appointments.FirstOrDefault(a => a.Id == request.Id);

            if (appointment == null)
            {
                throw new Exception("Appointment is already existed");
            }

            appointment = new Appointment()
            {
                Id = request.Id,
                PatientId = request.PatientId,
                DoctorId = request.DoctorId,
                Date = request.Date,
                Status = request.Status
            };

            _context.Appointments.Add(appointment);
            _context.SaveChanges();

            return appointment;
        }

        public Appointment Update(Appointment request)
        {
            var appointment = _context.Appointments.FirstOrDefault(a => a.Id == request.Id);

            if (appointment == null)
            {
                throw new Exception("Appointment not exist");
            }

            appointment.PatientId = request.PatientId;
            appointment.DoctorId = request.DoctorId;
            appointment.Date = request.Date;
            appointment.Status = request.Status;

            _context.Appointments.Update(appointment);
            _context.SaveChanges();

            return appointment;
        }

        public bool Delete(string id)
        {
            var appointment = _context.Appointments.FirstOrDefault(a => a.Id == id);

            if (appointment == null)
            {
                return false;
            }

            _context.Appointments.Remove(appointment);
            _context.SaveChanges();

            return true;
        }
    }
}

using HealthcareAppointment.Models;

namespace HealthcareAppointment.Bussiness
{
    public interface IUserService
    {
        List<User> GetList();

        User Create(User request);

        User Update(User request);

        bool Delete(string id);
    }
    public class UserService : IUserService
    {
        HealthcareAppointmentContext _context;
        public UserService(HealthcareAppointmentContext context)
        {
            _context = context;
        }

        public List<User> GetList()
        {
            return _context.Users.ToList();
        }

        public User Create(User request)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == request.Id);

            if (user == null)
            {
                throw new Exception("User is already existed");
            }

            user = new User()
            {
                Id = request.Id,
                Name = request.Name,
                Email = request.Email,
                DateOfBirth = request.DateOfBirth,
                Password = request.Password,
                Role = request.Role,
                Specialization = request.Specialization
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }
        public User Update(User request)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == request.Id);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            user.Name = request.Name;
            user.Email = request.Email;
            user.DateOfBirth = request.DateOfBirth;
            user.Password = request.Password;
            user.Role = request.Role;
            user.Specialization = request.Specialization;

            _context.Users.Update(user);
            _context.SaveChanges();

            return user;
        }

        public bool Delete(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return false;
            }

            _context.Users.Remove(user);
            _context.SaveChanges();

            return true;
        }
    }
}

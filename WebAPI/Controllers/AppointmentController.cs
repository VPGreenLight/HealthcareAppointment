using Microsoft.AspNetCore.Mvc;

namespace HealthcareAppointment.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

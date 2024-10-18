using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace HealthcareAppointment.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProtectedController : Controller
    {
        [HttpGet]
        public IActionResult GetProtectedData()
        {
            return Ok("This is protected data!");
        }
    }
}

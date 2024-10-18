using HealthcareAppointment.Bussiness;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareAppointment.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public List<Models.User> Get()
        {
            return _userService.GetList();
        }

        [HttpPost]
        public Models.User Create([FromBody] Models.User request)
        {
            return _userService.Create(request);
        }

        [HttpPut("{code}")]
        public Models.User Update(string id, [FromBody] Models.User request)
        {
            request.Id = id;
            return _userService.Update(request);
        }

        [HttpDelete("{code}")]
        public bool Delete(string id)
        {
            return _userService.Delete(id);
        }
    }
}

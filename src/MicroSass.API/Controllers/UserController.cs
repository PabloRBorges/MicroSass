using MicroSass.Application;
using Microsoft.AspNetCore.Mvc;

namespace MicroSass.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(Guid id)
        {
            var user = _userService.GetUser(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var user = _userService.GetAll();
            if (user == null) return NotFound();
            return Ok(user);
        }


        [HttpPost]
        public IActionResult RegisterUser(string name, string email)
        {
            _userService.RegisterUser(name, email);
            return Ok();
        }

        [HttpPut("{id}/email")]
        public IActionResult UpdateEmail(Guid id, string email)
        {
            _userService.UpdateUserEmail(id, email);
            return Ok();
        }
    }
}

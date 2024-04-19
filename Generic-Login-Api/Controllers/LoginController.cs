using BusinessLayer.Dto_s;
using BusinessLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Generic_Login_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private ILoginService _service;
        public LoginController(ILoginService service)
        {
            _service = service;
        }
        [HttpGet("/Login")]
        public IActionResult Login([FromBody] LoginCredentialsDTO credentials)
        {
            var response = _service.Login(credentials);
            return Ok(response);
        }
    }
}

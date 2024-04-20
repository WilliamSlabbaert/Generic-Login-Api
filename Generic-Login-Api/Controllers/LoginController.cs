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
        public async Task<IActionResult> Login([FromBody] LoginCredentialsDTO credentials)
        {
            try
            {
                var response = await _service.Login(credentials);

                return response ? Ok("Het is ok")
                    : Unauthorized("No account found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

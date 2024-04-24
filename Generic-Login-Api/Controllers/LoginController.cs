using BusinessLayer.Dto_s;
using BusinessLayer.Services.Interfaces;
using Generic_Login_Api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Generic_Login_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private ILoginService _service;
        private IConfiguration _config;
        public LoginController(ILoginService service, IConfiguration config)
        {
            _service = service;
            _config = config;
        }
        [HttpPost("/Login")]
        public async Task<IActionResult> Login([FromBody] LoginCredentialsDTO credentials)
        {
            try
            {
                var response = await _service.Login(credentials);

                return response ? Ok(JwtTokenHelper.GetJwtToken(_config))
                    : Unauthorized("No account found.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/Register")]
        public async Task<IActionResult> Register([FromBody] LoginCredentialsDTO credentials)
        {
            try
            {
                await _service.Register(credentials);

                return Ok("Registered");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/Test")]
        [Authorize]
        public async Task<IActionResult> Test()
        {
            return Ok(_config["MY_KEY"]);
        }
    }
}

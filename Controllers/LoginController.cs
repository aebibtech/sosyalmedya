using jsonapisample.Models.Integration;
using jsonapisample.Services;
using Microsoft.AspNetCore.Mvc;

namespace jsonapisample.Controllers
{
    public class LoginController(LoginService loginService) : ControllerBase
    {
        private readonly LoginService _loginService = loginService;

        [HttpPost("/api/v{apiVersion}/users/login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            bool result = await _loginService.Login(request);
            return Ok(new { result });
        }
    }
}

using Aplicacion.Interfaces;
using Aplicacion.Main;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        
        private readonly ILoginAplication _loginAplication;

        public LoginController(ILoginAplication loginAplication)
        {
            _loginAplication = loginAplication;
        }

        [HttpGet(Name = "GetLogin")]
        public async Task<IActionResult> GetLogin(string email, string password)
        {
            var result = await _loginAplication.GetLogin(email, password);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

    }
}
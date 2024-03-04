using Aplicacion.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Aplicacion.Main;
using Aplicacion.DTO;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UpusersController : ControllerBase
    {

        private readonly IUpusersAplications _UpusersAplication;

        public UpusersController(IUpusersAplications UpusersAplication)
        {
            _UpusersAplication = UpusersAplication;
        }

        [HttpPost(Name = "PostAllDataUser")]
        public async Task<IActionResult> PostAllDataUser(string prinombre, string segnombre, string priapellido, string segapellido, string telefono, string correo, string username, string password)
        {
            var result = await _UpusersAplication.PostAllDataUser(string prinombre, string segnombre, string priapellido, string segapellido, string telefono, string correo, string username, string password);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
    }
}


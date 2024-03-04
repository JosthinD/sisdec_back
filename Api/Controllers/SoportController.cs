using Aplicacion.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Aplicacion.Main;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SoportController : ControllerBase
    {

        private readonly IUsersAplication _soportAplication;

        public SoportController(IUsersAplication usersAplication)
        {
            _soportAplication = usersAplication;
        }

        [HttpGet(Name = "GetAllDataSoport")]
        public async Task<IActionResult> GetAllDataSoport(int idcaso)
        {
            var result = await _soportAplication.GetAllDataSoport(idcaso);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}

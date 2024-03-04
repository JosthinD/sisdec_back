using Aplicacion.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IDataAplication _dataAplication;

        public DataController(IDataAplication dataAplication)
        {
            _dataAplication = dataAplication;
        }
        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var result = await _dataAplication.GetAllRoles();
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}

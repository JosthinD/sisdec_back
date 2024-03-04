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
        [HttpGet("GetAllGenres")]
        public async Task<IActionResult> GetAllGenres()
        {
            var result = await _dataAplication.GetAllGenres();
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpGet("GetAllDocumentTypes")]
        public async Task<IActionResult> GetAllDocumentTypes()
        {
            var result = await _dataAplication.GetAllDocumentTypes();
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpGet("GetAllStates")]
        public async Task<IActionResult> GetAllStates()
        {
            var result = await _dataAplication.GetAllStates();
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}

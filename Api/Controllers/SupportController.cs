using Aplicacion.DTO;
using Aplicacion.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportController : ControllerBase
    {
        private readonly ISupportAplication _supportAplication;

        public SupportController(ISupportAplication supportAplication)
        {
            _supportAplication = supportAplication;
        }
        [HttpGet("GetAllSoportes")]
        public async Task<IActionResult> GetAllSoportes()
        {
            var result = await _supportAplication.GetAllSoportes();
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpGet("GetSoportesByUserId")]
        public async Task<IActionResult> GetSoportesByUserId(int userId)
        {
            var result = await _supportAplication.GetSoportesByUserId(userId);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpGet("GetSoportesByEstadoId")]
        public async Task<IActionResult> GetSoportesByEstadoId(int estadoId)
        {
            var result = await _supportAplication.GetSoportesByEstadoId(estadoId);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpGet("GetSoportesByFilters")]
        public async Task<IActionResult> GetSoportesByFilters(DateTime? fecha, int? userId, int? estadoId)
        {
            var result = await _supportAplication.GetSoportesByFilters(fecha,userId,estadoId);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPut("UpdateSoporteEstado")]
        public async Task<IActionResult> UpdateSoporteEstado([FromBody] ActualizarEstadoSoporteDto soporteDto)
        {
            var result = await _supportAplication.UpdateSoporteEstado(soporteDto.SoporteId, soporteDto.NuevoEstadoId);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPost("NewSoporte")]
        public async Task<IActionResult> NewSoporte([FromBody] NewSoporteDto newSoporteDto)
        {
            var result = await _supportAplication.NewSoporte(newSoporteDto.Asunto, newSoporteDto.Descripcion, newSoporteDto.IdUsuario);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}

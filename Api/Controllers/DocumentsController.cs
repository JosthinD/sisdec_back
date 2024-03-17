using Aplicacion.Interfaces;
using Aplicacion.Main;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Entities;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : Controller
    {
        public readonly IDocumentsAplication _documentsAplication;
        public DocumentsController(IDocumentsAplication documentsAplication)
        {
            _documentsAplication = documentsAplication;
        }
        [HttpGet("GetAllPlanAccionAcademico")]
        public async Task<IActionResult> GetAllRoles()
        {
            var result = await _documentsAplication.GetAllPlanAccionAcademico();
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpGet("GetAllPlanAccionAcademicoPorUsuario")]
        public async Task<IActionResult> GetAllPlanAccionAcademicoPorUsuario(int IdUsuario)
        {
            var result = await _documentsAplication.GetAllPlanAccionAcademicoPorUsuario(IdUsuario);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPost("AgregarNuevoPlanAccion")]
        public async Task<IActionResult> AgregarNuevoPlanAccion([FromBody]PlanAccionAcademicoDto nuevoPlan)
        {
            if(nuevoPlan == null) return BadRequest("Se debe ingresar el nuevo plan a agregar.");
            var result = await _documentsAplication.AgregarNuevoPlanAccion(nuevoPlan);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPut("ActualizarPlanAccion")]
        public async Task<IActionResult> ActualizarPlanAccion([FromBody] PlanAccionAcademico planActualizado)
        {
            if (planActualizado == null) return BadRequest("Se debe ingresar el plan a actualizar.");
            var result = await _documentsAplication.ActualizarPlanAccion(planActualizado);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}

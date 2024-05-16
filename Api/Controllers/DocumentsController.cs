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
        public async Task<IActionResult> GetAllPlanAccionAcademico()
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
        //=========================================================================================================================
        [HttpGet("GetAllPracticaPorAsignatura")]
        public async Task<IActionResult> GetAllPracticaPorAsignatura()
        {
            var result = await _documentsAplication.GetAllPracticaPorAsignatura();
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpGet("GetAllPracticaPorAsignaturaPorUsuario")]
        public async Task<IActionResult> GetAllPracticaPorAsignaturaPorUsuario(int IdUsuario)
        {
            var result = await _documentsAplication.GetAllPracticaPorAsignaturaPorUsuario(IdUsuario);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPost("AgregarNuevaPracticaPorAsignatura")]
        public async Task<IActionResult> AgregarNuevaPracticaPorAsignatura([FromBody] PracticaPorAsignaturaDto nuevaPractica)
        {
            if (nuevaPractica == null) return BadRequest("Se debe ingresar el nuevo plan a agregar.");
            var result = await _documentsAplication.AgregarNuevaPracticaPorAsignatura(nuevaPractica);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPut("ActualizarPracticaPorAsignatura")]
        public async Task<IActionResult> ActualizarPracticaPorAsignatura([FromBody] PracticaPorAsignatura practicaActualizada)
        {
            if (practicaActualizada == null) return BadRequest("Se debe ingresar el plan a actualizar.");
            var result = await _documentsAplication.ActualizarPracticaPorAsignatura(practicaActualizada);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
        //=========================================================================================================================
        [HttpGet("GetAllAtencionEstudiantes")]
        public async Task<IActionResult> GetAllAtencionEstudiantes()
        {
            var result = await _documentsAplication.GetAllAtencionEstudiantes();
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpGet("GetAllAtencionEstudiantesPorUsuario")]
        public async Task<IActionResult> GetAllAtencionEstudiantesPorUsuario(int IdUsuario)
        {
            var result = await _documentsAplication.GetAllAtencionEstudiantesPorUsuario(IdUsuario);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPost("AgregarNuevaAtencionEstudiantes")]
        public async Task<IActionResult> AgregarNuevaAtencionEstudiantes([FromBody] AtencionEstudiantesDto nuevaAtencion)
        {
            if (nuevaAtencion == null) return BadRequest("Se debe ingresar el nuevo atencion a agregar.");
            var result = await _documentsAplication.AgregarNuevaAtencionEstudiantes(nuevaAtencion);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPut("ActualizarAtencionEstudiantes")]
        public async Task<IActionResult> ActualizarAtencionEstudiantes([FromBody] AtencionEstudiantes nuevaAtencion)
        {
            if (nuevaAtencion == null) return BadRequest("Se debe ingresar el plan a actualizar.");
            var result = await _documentsAplication.ActualizarAtencionEstudiantes(nuevaAtencion);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
        //=========================================================================================================================
    }
}

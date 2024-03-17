using Aplicacion.DTO;
using Repositorio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces
{
    public interface IDocumentsAplication
    {
        Task<ResponseDto<List<PlanAccionAcademico?>>> GetAllPlanAccionAcademico();
        Task<ResponseDto<List<PlanAccionAcademico?>>> GetAllPlanAccionAcademicoPorUsuario(int IdUsuario);
        Task<ResponseDto<bool>> AgregarNuevoPlanAccion(PlanAccionAcademicoDto nuevoPlan);
        Task<ResponseDto<bool>> ActualizarPlanAccion(PlanAccionAcademico planActualizado);
    }
}

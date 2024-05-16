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
        //=============================================================================
        Task<ResponseDto<List<PracticaPorAsignatura?>>> GetAllPracticaPorAsignatura();
        Task<ResponseDto<List<PracticaPorAsignatura?>>> GetAllPracticaPorAsignaturaPorUsuario(int IdUsuario);
        Task<ResponseDto<bool>> AgregarNuevaPracticaPorAsignatura(PracticaPorAsignaturaDto nuevaPractica);
        Task<ResponseDto<bool>> ActualizarPracticaPorAsignatura(PracticaPorAsignatura practicaActualizada);
        //=============================================================================
        Task<ResponseDto<List<AtencionEstudiantes?>>> GetAllAtencionEstudiantes();
        Task<ResponseDto<List<AtencionEstudiantes?>>> GetAllAtencionEstudiantesPorUsuario(int IdUsuario);
        Task<ResponseDto<bool>> AgregarNuevaAtencionEstudiantes(AtencionEstudiantesDto nuevaAtencion);
        Task<ResponseDto<bool>> ActualizarAtencionEstudiantes(AtencionEstudiantes atencionActualizada);
        //=============================================================================
    }
}

using Repositorio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interfaces
{
    public interface IDocumentsRepository
    {
        Task<List<PlanAccionAcademico>> GetAllPlanAccionAcademico();
        Task<List<PlanAccionAcademico>> GetAllPlanAccionAcademicoPorUsuario(int usuarioId);
        Task<bool> AgregarNuevoPlanAccion(PlanAccionAcademicoDto nuevoPlan);
        Task<bool> ActualizarPlanAccion(PlanAccionAcademico planActualizado);
        Task<List<PracticaPorAsignatura>> GetAllPracticaPorAsignatura();
        Task<List<PracticaPorAsignatura>> GetAllPracticaPorAsignaturaPorUsuario(int IdUsuario);
        Task<bool> AgregarNuevaPracticaPorAsignatura(PracticaPorAsignaturaDto nuevaPractica);
        Task<bool> ActualizarPracticaPorAsignatura(PracticaPorAsignatura practicaActualizada);
    }
}

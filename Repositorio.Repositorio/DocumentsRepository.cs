using Microsoft.EntityFrameworkCore;
using Repositorio.Data;
using Repositorio.Entities;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Repositorio
{
    public class DocumentsRepository: IDocumentsRepository
    {
        private readonly DataContext Context;
        public DocumentsRepository(DataContext context)
        {
            Context = context;
        }
        public async Task<List<PlanAccionAcademico>> GetAllPlanAccionAcademico()
        {
            return await Context.PlanAccionAcademico.ToListAsync();
        }
        public async Task<List<PlanAccionAcademico>> GetAllPlanAccionAcademicoPorUsuario(int IdUsuario)
        {
            return await Context.PlanAccionAcademico
                .Where(plan => plan.IdUsuario == IdUsuario)
                .ToListAsync();
        }
        public async Task<bool> AgregarNuevoPlanAccion(PlanAccionAcademicoDto nuevoPlan)
        {
            try
            {

                var plan = new PlanAccionAcademico
                {
                    Programa = nuevoPlan.Programa,
                    Fecha = nuevoPlan.Fecha,
                    Director = nuevoPlan.Director,
                    FechaDos = nuevoPlan.FechaDos,
                    Actividad = nuevoPlan.Actividad,
                    Descripcion = nuevoPlan.Descripcion,
                    Duracion = nuevoPlan.Duracion,
                    Lugar = nuevoPlan.Lugar,
                    HoraInicio = nuevoPlan.HoraInicio,
                    HoraFin = nuevoPlan.HoraFin,
                    Responsable = nuevoPlan.Responsable,
                    Participantes = nuevoPlan.Participantes,
                    Evidencias = nuevoPlan.Evidencias,
                    IdUsuario = nuevoPlan.IdUsuario
                };

                Context.PlanAccionAcademico.Add(plan);
                await Context.SaveChangesAsync();
                return true;
            }// Se agregó correctamente el nuevo plan
            catch (Exception)
            {
                // Manejar cualquier excepción aquí, por ejemplo, registrarla o devolver un mensaje de error
                return false; // Falló al agregar el nuevo plan
            }
        }
        public async Task<bool> ActualizarPlanAccion(PlanAccionAcademico planActualizado)
        {
            try
            {
                var planExistente = await Context.PlanAccionAcademico.FindAsync(planActualizado.Id);

                if (planExistente == null)
                {
                    throw new Exception($"No se encontró el plan con ID {planActualizado.Id}.");
                }

                // Actualizar las propiedades necesarias
                planExistente.Programa = planActualizado.Programa;
                planExistente.Fecha = planActualizado.Fecha;
                planExistente.Director = planActualizado.Director;
                planExistente.FechaDos = planActualizado.FechaDos;
                planExistente.Actividad = planActualizado.Actividad;
                planExistente.Descripcion = planActualizado.Descripcion;
                planExistente.Duracion = planActualizado.Duracion;
                planExistente.Lugar = planActualizado.Lugar;
                planExistente.HoraInicio = planActualizado.HoraInicio;
                planExistente.HoraFin = planActualizado.HoraFin;
                planExistente.Responsable = planActualizado.Responsable;
                planExistente.Participantes = planActualizado.Participantes;
                planExistente.Evidencias = planActualizado.Evidencias;
                planExistente.IdUsuario = planActualizado.IdUsuario;

                await Context.SaveChangesAsync();
                return true; // Se actualizó correctamente el plan
            }
            catch (Exception)
            {
                // Manejar cualquier excepción aquí, por ejemplo, registrarla o devolver un mensaje de error
                return false; // Falló al actualizar el plan
            }
        }
    }
}

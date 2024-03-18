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

        //=================================================================================================================
        public async Task<List<PracticaPorAsignatura>> GetAllPracticaPorAsignatura()
        {
            return await Context.PracticaPorAsignatura.ToListAsync();
        }
        public async Task<List<PracticaPorAsignatura>> GetAllPracticaPorAsignaturaPorUsuario(int IdUsuario)
        {
            return await Context.PracticaPorAsignatura
                .Where(plan => plan.IdUsuario == IdUsuario)
                .ToListAsync();
        }
        public async Task<bool> AgregarNuevaPracticaPorAsignatura(PracticaPorAsignaturaDto nuevaPractica)
        {
            try
            {
                var practica = new PracticaPorAsignatura
                {
                    Programa = nuevaPractica.Programa,
                    Director = nuevaPractica.Director,
                    Semestre = nuevaPractica.Semestre,
                    NombrePractica = nuevaPractica.NombrePractica,
                    NumeroPractica = nuevaPractica.NumeroPractica,
                    Lugar = nuevaPractica.Lugar,
                    Horas = nuevaPractica.Horas,
                    Observaciones = nuevaPractica.Observaciones,
                    Introduccion = nuevaPractica.Introduccion,
                    ObjetivoGeneral = nuevaPractica.ObjetivoGeneral,
                    ObjetivosEspecificos = nuevaPractica.ObjetivosEspecificos,
                    EvidenciasActividades = nuevaPractica.EvidenciasActividades,
                    ObjetosUsados = nuevaPractica.ObjetosUsados,
                    ResultadoAprendizaje = nuevaPractica.ResultadoAprendizaje,
                    EvaluacionPractica = nuevaPractica.EvaluacionPractica,
                    IdUsuario = nuevaPractica.IdUsuario
                };

                Context.PracticaPorAsignatura.Add(practica);
                await Context.SaveChangesAsync();
                return true; // Se agregó correctamente la nueva práctica
            }
            catch (Exception)
            {
                // Manejar cualquier excepción aquí, por ejemplo, registrarla o devolver un mensaje de error
                return false; // Falló al agregar la nueva práctica
            }
        }
        public async Task<bool> ActualizarPracticaPorAsignatura(PracticaPorAsignatura practicaActualizada)
        {
            try
            {
                var practicaExistente = await Context.PracticaPorAsignatura.FindAsync(practicaActualizada.Id);

                if (practicaExistente == null)
                {
                    throw new Exception($"No se encontró la práctica con ID {practicaActualizada.Id}.");
                }

                // Actualizar las propiedades necesarias
                practicaExistente.Programa = practicaActualizada.Programa;
                practicaExistente.Director = practicaActualizada.Director;
                practicaExistente.Semestre = practicaActualizada.Semestre;
                practicaExistente.NombrePractica = practicaActualizada.NombrePractica;
                practicaExistente.NumeroPractica = practicaActualizada.NumeroPractica;
                practicaExistente.Lugar = practicaActualizada.Lugar;
                practicaExistente.Horas = practicaActualizada.Horas;
                practicaExistente.Observaciones = practicaActualizada.Observaciones;
                practicaExistente.Introduccion = practicaActualizada.Introduccion;
                practicaExistente.ObjetivoGeneral = practicaActualizada.ObjetivoGeneral;
                practicaExistente.ObjetivosEspecificos = practicaActualizada.ObjetivosEspecificos;
                practicaExistente.EvidenciasActividades = practicaActualizada.EvidenciasActividades;
                practicaExistente.ObjetosUsados = practicaActualizada.ObjetosUsados;
                practicaExistente.ResultadoAprendizaje = practicaActualizada.ResultadoAprendizaje;
                practicaExistente.EvaluacionPractica = practicaActualizada.EvaluacionPractica;
                practicaExistente.IdUsuario = practicaActualizada.IdUsuario;

                await Context.SaveChangesAsync();
                return true; // Se actualizó correctamente la práctica
            }
            catch (Exception)
            {
                // Manejar cualquier excepción aquí, por ejemplo, registrarla o devolver un mensaje de error
                return false; // Falló al actualizar la práctica
            }
        }

    }
}

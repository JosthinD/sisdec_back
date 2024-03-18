using Aplicacion.DTO;
using Aplicacion.Interfaces;
using Repositorio.Entities;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Main
{
    public class DocumentsAplication: IDocumentsAplication
    {
        public readonly IDocumentsRepository _documentsRepository;
        public DocumentsAplication(IDocumentsRepository documentsRepository)
        {

            _documentsRepository = documentsRepository;

        }
        public async Task<ResponseDto<List<PlanAccionAcademico?>>> GetAllPlanAccionAcademico()
        {
            var data = new ResponseDto<List<PlanAccionAcademico>?> { Data = new List<PlanAccionAcademico>() };
            try
            {
                var roles = await _documentsRepository.GetAllPlanAccionAcademico();
                if (!roles.Any())
                {
                    data.IsSuccess = false;
                    data.Response = "400";
                    data.Message = "Problemas en la consulta de todos los Planes de Accion Academico a la base de datos.";
                    return data;
                }

                data.IsSuccess = true;
                data.Response = "200";
                data.Message = "Planes de Accion Academico";
                data.Data = roles;
                return data;
            }
            catch (Exception ex)
            {
                data.IsSuccess = false;
                data.Message = "Error: En consulta de los Planes de Accion Academico" + ex.Message;
                data.Response = "500";
                return data;
            }
        }
        public async Task<ResponseDto<List<PlanAccionAcademico?>>> GetAllPlanAccionAcademicoPorUsuario(int IdUsuario)
        {
            var data = new ResponseDto<List<PlanAccionAcademico>?> { Data = new List<PlanAccionAcademico>() };
            try
            {
                var roles = await _documentsRepository.GetAllPlanAccionAcademicoPorUsuario(IdUsuario);
                if (!roles.Any())
                {
                    data.IsSuccess = false;
                    data.Response = "400";
                    data.Message = "Problemas en la consulta de todos los Planes de Accion Academico por usuario a la base de datos.";
                    return data;
                }

                data.IsSuccess = true;
                data.Response = "200";
                data.Message = "Planes de Accion Academico por usuario";
                data.Data = roles;
                return data;
            }
            catch (Exception ex)
            {
                data.IsSuccess = false;
                data.Message = "Error: En consulta de los Planes de Accion Academico por usuario" + ex.Message;
                data.Response = "500";
                return data;
            }
        }
        public async Task<ResponseDto<bool>> AgregarNuevoPlanAccion(PlanAccionAcademicoDto nuevoPlan)
        {
            var data = new ResponseDto<bool> { Data = false };
            try
            {
                var result = await _documentsRepository.AgregarNuevoPlanAccion(nuevoPlan);
                if (!result)
                {
                    data.IsSuccess = false;
                    data.Response = "400";
                    data.Message = "Problemas al agregar el Plan de Accion Academico a la base de datos.";
                    return data;
                }

                data.IsSuccess = true;
                data.Response = "200";
                data.Message = "Planes de Accion Academico agregado";
                data.Data = result;
                return data;
            }
            catch (Exception ex)
            {
                data.IsSuccess = false;
                data.Message = "Error: En agregar Plan de Accion Academico" + ex.Message;
                data.Response = "500";
                return data;
            }
        }
        public async Task<ResponseDto<bool>> ActualizarPlanAccion(PlanAccionAcademico planActualizado)
        {
            var data = new ResponseDto<bool> { Data = false };
            try
            {
                var result = await _documentsRepository.ActualizarPlanAccion(planActualizado);
                if (!result)
                {
                    data.IsSuccess = false;
                    data.Response = "400";
                    data.Message = "Problemas al actualizar el Plan de Accion Academico a la base de datos.";
                    return data;
                }

                data.IsSuccess = true;
                data.Response = "200";
                data.Message = "Planes de Accion Academico actualizado";
                data.Data = result;
                return data;
            }
            catch (Exception ex)
            {
                data.IsSuccess = false;
                data.Message = "Error: En actualizar Plan de Accion Academico" + ex.Message;
                data.Response = "500";
                return data;
            }
        }
        //===========================================================================================================================
        public async Task<ResponseDto<List<PracticaPorAsignatura?>>> GetAllPracticaPorAsignatura()
        {
            var data = new ResponseDto<List<PracticaPorAsignatura>?> { Data = new List<PracticaPorAsignatura>() };
            try
            {
                var roles = await _documentsRepository.GetAllPracticaPorAsignatura();
                if (!roles.Any())
                {
                    data.IsSuccess = false;
                    data.Response = "400";
                    data.Message = "Problemas en la consulta de todas las practicas por asignatura a la base de datos.";
                    return data;
                }

                data.IsSuccess = true;
                data.Response = "200";
                data.Message = "todas las practicas por asignatura";
                data.Data = roles;
                return data;
            }
            catch (Exception ex)
            {
                data.IsSuccess = false;
                data.Message = "Error: En consulta de todas las practicas por asignatura" + ex.Message;
                data.Response = "500";
                return data;
            }
        }
        public async Task<ResponseDto<List<PracticaPorAsignatura?>>> GetAllPracticaPorAsignaturaPorUsuario(int IdUsuario)
        {
            var data = new ResponseDto<List<PracticaPorAsignatura>?> { Data = new List<PracticaPorAsignatura>() };
            try
            {
                var roles = await _documentsRepository.GetAllPracticaPorAsignaturaPorUsuario(IdUsuario);
                if (!roles.Any())
                {
                    data.IsSuccess = false;
                    data.Response = "400";
                    data.Message = "Problemas en la consulta de todas las practicas por asignatura por usuario a la base de datos.";
                    return data;
                }

                data.IsSuccess = true;
                data.Response = "200";
                data.Message = "todas las practicas por asignatura por usuario";
                data.Data = roles;
                return data;
            }
            catch (Exception ex)
            {
                data.IsSuccess = false;
                data.Message = "Error: En consulta de todas las practicas por asignatura por usuario" + ex.Message;
                data.Response = "500";
                return data;
            }
        }
        public async Task<ResponseDto<bool>> AgregarNuevaPracticaPorAsignatura(PracticaPorAsignaturaDto nuevaPractica)
        {
            var data = new ResponseDto<bool> { Data = false };
            try
            {
                var result = await _documentsRepository.AgregarNuevaPracticaPorAsignatura(nuevaPractica);
                if (!result)
                {
                    data.IsSuccess = false;
                    data.Response = "400";
                    data.Message = "Problemas al agregar la practica por asignatura a la base de datos.";
                    return data;
                }

                data.IsSuccess = true;
                data.Response = "200";
                data.Message = "la practica por asignatura agregado";
                data.Data = result;
                return data;
            }
            catch (Exception ex)
            {
                data.IsSuccess = false;
                data.Message = "Error: En agregar la practica por asignatura" + ex.Message;
                data.Response = "500";
                return data;
            }
        }
        public async Task<ResponseDto<bool>> ActualizarPracticaPorAsignatura(PracticaPorAsignatura practicaActualizada)
        {
            var data = new ResponseDto<bool> { Data = false };
            try
            {
                var result = await _documentsRepository.ActualizarPracticaPorAsignatura(practicaActualizada);
                if (!result)
                {
                    data.IsSuccess = false;
                    data.Response = "400";
                    data.Message = "Problemas al actualizar la practica por asignatura a la base de datos.";
                    return data;
                }

                data.IsSuccess = true;
                data.Response = "200";
                data.Message = "la practica por asignatura actualizado";
                data.Data = result;
                return data;
            }
            catch (Exception ex)
            {
                data.IsSuccess = false;
                data.Message = "Error: En actualizar la practica por asignatura" + ex.Message;
                data.Response = "500";
                return data;
            }
        }
    }
}

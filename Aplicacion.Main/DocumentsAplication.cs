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
    }
}

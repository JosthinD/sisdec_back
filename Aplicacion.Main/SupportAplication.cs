using Aplicacion.DTO;
using Aplicacion.Interfaces;
using Repositorio.Entities;
using Repositorio.Interfaces;
using Repositorio.Repositorio;

namespace Aplicacion.Main
{
    public class SupportAplication : ISupportAplication
    {
        private readonly ISupportRepository _supportRepository;
        private readonly IDataRepository _dataRepository;
        public SupportAplication(ISupportRepository _SupportRepository, IDataRepository _DataRepository)
        {
            _supportRepository = _SupportRepository;
            _dataRepository = _DataRepository;
        }
              
        public async Task<ResponseDto<List<Soportes?>>> GetAllSoportes()
        {
            var data = new ResponseDto<List<Soportes>?> { Data = new List<Soportes>() };
            try
            {
                var soportes = await _supportRepository.GetAllSoportes();
                if (!soportes.Any())
                {
                    data.IsSuccess = false;
                    data.Response = "400";
                    data.Message = "No hay soportes.";
                    return data;
                }

                data.IsSuccess = true;
                data.Response = "200";
                data.Message = "Todos los soportes";
                data.Data = soportes;
                return data;
            }
            catch (Exception ex)
            {
                data.IsSuccess = false;
                data.Message = "Error: En consulta de Soportes" + ex.Message;
                data.Response = "500";
                return data;
            }
        }
        public async Task<ResponseDto<List<Soportes?>>> GetSoportesByUserId(int userId)
        {
            var data = new ResponseDto<List<Soportes>?> { Data = new List<Soportes>() };
            try
            {
                var soportes = await _supportRepository.GetSoportesByUserId(userId);
                if (!soportes.Any())
                {
                    data.IsSuccess = false;
                    data.Response = "400";
                    data.Message = "No hay soportes para este usuario";
                    return data;
                }

                data.IsSuccess = true;
                data.Response = "200";
                data.Message = "Todos los soportes del usuario";
                data.Data = soportes;
                return data;
            }
            catch (Exception ex)
            {
                data.IsSuccess = false;
                data.Message = "Error: En consulta de Soportes por usuario" + ex.Message;
                data.Response = "500";
                return data;
            }
        }
        public async Task<ResponseDto<List<Soportes?>>> GetSoportesByEstadoId(int estadoId)
        {
            var data = new ResponseDto<List<Soportes>?> { Data = new List<Soportes>() };
            try
            {
                var soportes = await _supportRepository.GetSoportesByEstadoId(estadoId);
                if (!soportes.Any())
                {
                    data.IsSuccess = false;
                    data.Response = "400";
                    data.Message = "No hay soportes por ese id";
                    return data;
                }

                data.IsSuccess = true;
                data.Response = "200";
                data.Message = "Todos los soportes por estado";
                data.Data = soportes;
                return data;
            }
            catch (Exception ex)
            {
                data.IsSuccess = false;
                data.Message = "Error: En consulta de Soportes por estado" + ex.Message;
                data.Response = "500";
                return data;
            }
        }
        public async Task<ResponseDto<List<Soportes?>>> GetSoportesByFilters(DateTime? fecha, int? userId, int? estadoId)
        {
            var data = new ResponseDto<List<Soportes>?> { Data = new List<Soportes>() };
            try
            {
                var soportes = await _supportRepository.GetSoportesByFilters(fecha,userId,estadoId);
                if (!soportes.Any())
                {
                    data.IsSuccess = false;
                    data.Response = "200";
                    data.Message = "No hay soportes con esos filtros";
                    return data;
                }

                data.IsSuccess = true;
                data.Response = "200";
                data.Message = "Todos los soportes por multiples filtros";
                data.Data = soportes;
                return data;
            }
            catch (Exception ex)
            {
                data.IsSuccess = false;
                data.Message = "Error: En consulta de Soportes por multiples filtros" + ex.Message;
                data.Response = "500";
                return data;
            }
        }
        public async Task<ResponseDto<bool>> UpdateSoporteEstado(int soporteId, int nuevoEstadoId)
        {
            var data = new ResponseDto<bool> { Data = false };
            try
            {
                var status = await _supportRepository.UpdateSoporteEstado(soporteId, nuevoEstadoId);
                if (!status)
                {
                    data.IsSuccess = status;
                    data.Response = "400";
                    data.Message = "Soporte no existe, no se actualizo estado.";
                    return data;
                }
                var log = await _dataRepository.AddNewLog(
                    new Logs
                    {
                        IdAccion = 5,
                        Descripcion = string.Format("Se realizo actualización de estado de soporte con ID = {0}", soporteId)
                    });
                data.IsSuccess = true;
                data.Response = "200";
                data.Message = "Actualizacion Completada.";
                data.Data = status;
                return data;
            }
            catch (Exception ex)
            {
                data.IsSuccess = false;
                data.Message = "Error: " + ex.Message;
                data.Response = "500";
                return data;
            }
        }
        public async Task<ResponseDto<bool>> NewSoporte(string asunto,string descripcion, int idUsuario)
        {
            var data = new ResponseDto<bool> { Data = false };
            try
            {
                var soporte = new Soportes();
                soporte.Asunto = asunto;
                soporte.Descripcion = descripcion;
                soporte.IdUsuario = idUsuario;
                soporte.Fecha = DateTime.Now;
                soporte.IdEstado = 1;
                var status = await _supportRepository.NewSoporte(soporte);
                if (!status)
                {
                    data.IsSuccess = status;
                    data.Response = "400";
                    data.Message = "Problema al agregar nuevo soporte.";
                    return data;
                }
                var log = await _dataRepository.AddNewLog(
                    new Logs
                    {
                        IdAccion = 1,
                        Descripcion = string.Format("Se Agrego nuevo soporte al usuario {0}", soporte.IdUsuario)
                    });
                data.IsSuccess = true;
                data.Response = "200";
                data.Message = "Soporte Agregado.";
                data.Data = status;
                return data;
            }
            catch (Exception ex)
            {
                data.IsSuccess = false;
                data.Message = "Error: " + ex.Message;
                data.Response = "500";
                return data;
            }
        }
    }
}
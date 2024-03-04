using Aplicacion.DTO;
using Aplicacion.Interfaces;
using Repositorio.Entities;
using Repositorio.Interfaces;

namespace Aplicacion.Main
{
    public class DataAplication : IDataAplication
    {
        private readonly IDataRepository _dataRepository;
        public DataAplication(IDataRepository _DataRepository)
        {
            _dataRepository = _DataRepository;
        }
              
        public async Task<ResponseDto<List<Roles?>>> GetAllRoles()
        {
            var data = new ResponseDto<List<Roles>?> { Data = new List<Roles>() };
            try
            {
                var roles = await _dataRepository.GetAllRoles();
                if (!roles.Any())
                {
                    data.IsSuccess = false;
                    data.Response = "400";
                    data.Message = "Problemas en la consulta de roles a la base de datos.";
                    return data;
                }

                data.IsSuccess = true;
                data.Response = "200";
                data.Message = "Roles";
                data.Data = roles;
                return data;
            }
            catch (Exception ex)
            {
                data.IsSuccess = false;
                data.Message = "Error: En consulta de Roles" + ex.Message;
                data.Response = "500";
                return data;
            }
        }

        public async Task<ResponseDto<List<Generos?>>> GetAllGenres()
        {
            var data = new ResponseDto<List<Generos>?> { Data = new List<Generos>() };
            try
            {
                var generos = await _dataRepository.GetAllGenres();
                if (!generos.Any())
                {
                    data.IsSuccess = false;
                    data.Response = "400";
                    data.Message = "Problemas en la consulta de generos a la base de datos.";
                    return data;
                }

                data.IsSuccess = true;
                data.Response = "200";
                data.Message = "Roles";
                data.Data = generos;
                return data;
            }
            catch (Exception ex)
            {
                data.IsSuccess = false;
                data.Message = "Error: En consulta de generos" + ex.Message;
                data.Response = "500";
                return data;
            }
        }
        public async Task<ResponseDto<List<TiposDocumento?>>> GetAllDocumentTypes()
        {
            var data = new ResponseDto<List<TiposDocumento>?> { Data = new List<TiposDocumento>() };
            try
            {
                var tipos = await _dataRepository.GetAllDocumentTypes();
                if (!tipos.Any())
                {
                    data.IsSuccess = false;
                    data.Response = "400";
                    data.Message = "Problemas en la consulta de tipos de documentos a la base de datos.";
                    return data;
                }

                data.IsSuccess = true;
                data.Response = "200";
                data.Message = "Tipos de Documentos";
                data.Data = tipos;
                return data;
            }
            catch (Exception ex)
            {
                data.IsSuccess = false;
                data.Message = "Error: En consulta de tipos de documentos" + ex.Message;
                data.Response = "500";
                return data;
            }
        }
        public async Task<ResponseDto<List<Estados?>>> GetAllStates()
        {
            var data = new ResponseDto<List<Estados>?> { Data = new List<Estados>() };
            try
            {
                var estados = await _dataRepository.GetAllStates();
                if (!estados.Any())
                {
                    data.IsSuccess = false;
                    data.Response = "400";
                    data.Message = "Problemas en la consulta de estados a la base de datos.";
                    return data;
                }

                data.IsSuccess = true;
                data.Response = "200";
                data.Message = "Estados";
                data.Data = estados;
                return data;
            }
            catch (Exception ex)
            {
                data.IsSuccess = false;
                data.Message = "Error: En consulta de estados" + ex.Message;
                data.Response = "500";
                return data;
            }
        }
    }
}
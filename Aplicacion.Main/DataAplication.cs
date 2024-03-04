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
    }
}
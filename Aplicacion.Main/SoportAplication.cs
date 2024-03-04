using Aplicacion.DTO;
using Aplicacion.Interfaces;
using Repositorio.Entities;
using Repositorio.Interfaces;

namespace Aplicacion.Main
{
    public class SoportAplication : ISoportAplication
    {
        private readonly ISoportRepository _soportRepository;
        public SoportAplication(ISoportRepository SoportRepository)
        {
            SoportRepository = SoportRepository;
        }

        public async Task<ResponseDto<soport?>> GetAllDataSoport(int idcaso)
        {
            var data = new ResponseDto<soport?> { Data = new soport() };
            try
            {
                bool existe = await _soportRepository.GetAllDataSoport(idcaso);
                if (!existe)
                {
                    data.IsSuccess = existe;
                    data.Response = "400";
                    data.Message = "No existe el usuario.";
                    return data;
                }

                data.IsSuccess = true;
                data.Response = "200";
                data.Message = "Datos Correctos.";
                data.Data = await _soportRepository.GetAllDataSoport(idcaso);
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
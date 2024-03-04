using Aplicacion.DTO;
using Repositorio.Entities;

namespace Aplicacion.Interfaces
{
    public interface ISoportAplication
    {
        Task<ResponseDto<soport?>> GetAllDataSoport(int idcaso);
    }
}

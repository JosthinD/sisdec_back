using Aplicacion.DTO;
using Repositorio.Entities;

namespace Aplicacion.Interfaces
{
    public interface IDataAplication
    {
        Task<ResponseDto<List<Roles?>>> GetAllRoles();
    }
}

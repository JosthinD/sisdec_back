using Aplicacion.DTO;
using Repositorio.Entities;

namespace Aplicacion.Interfaces
{
    public interface IUsersAplication
    {
        Task<ResponseDto<users?>> GetAllDataUser(string email);
    }
}

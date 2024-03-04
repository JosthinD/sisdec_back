using Aplicacion.DTO;
using Repositorio.Entities;

namespace Aplicacion.Interfaces
{
    public interface IUsersAplication
    {
        Task<ResponseDto<UsuariosDto?>> GetAllDataUser(string email);
    }
}

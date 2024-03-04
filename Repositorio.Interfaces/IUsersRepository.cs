using Aplicacion.DTO;
using Repositorio.Entities;

namespace Repositorio.Interfaces
{
    public interface IUsersRepository
    {      
        Task<UsuariosDto?> GetAllDataUser(string email);
    }
}
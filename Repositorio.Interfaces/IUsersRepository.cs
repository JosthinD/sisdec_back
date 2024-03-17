using Aplicacion.DTO;
using Repositorio.Entities;

namespace Repositorio.Interfaces
{
    public interface IUsersRepository
    {      
        Task<UsuariosDto?> GetAllDataUser(string email);
        Task<bool> UpdateUserData(UpdateUserDataDto usuarioActualizado);
        Task<List<UsuariosDto>> GetAllUsers();
        Task<bool> CreateNewUser(Usuarios newUser);
        Task<bool> VerifyPasswordForUser(int userId, string contraseña);
        Task<bool> UpdateUserPassword(int userId, string nuevaContraseña);
        Task<bool> UpdateUserState(int userId, int nuevoEstadoId);
        Task<bool> UpdateUserRole(int userId, int nuevoRolId);
    }
}
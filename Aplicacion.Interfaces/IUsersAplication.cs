using Aplicacion.DTO;
using Repositorio.Entities;

namespace Aplicacion.Interfaces
{
    public interface IUsersAplication
    {
        Task<ResponseDto<UsuariosDto?>> GetAllDataUser(string email);
        Task<ResponseDto<bool>> UpdateUserData(UpdateUserDataDto usuarioActualizado);
        Task<ResponseDto<List<UsuariosDto>>> GetAllUsers();
        Task<ResponseDto<bool>> CreateNewUser(Usuarios usuarioNuevo);
        Task<ResponseDto<bool>> VerifyPasswordForUser(int userId, string contraseña);
        Task<ResponseDto<bool>> UpdateUserPassword(int userId, string nuevaContraseña);
        Task<ResponseDto<bool>> UpdateUserState(int userId, int nuevoEstadoId);
        Task<ResponseDto<bool>> UpdateUserRole(int userId, int nuevoRolId);
    }
}

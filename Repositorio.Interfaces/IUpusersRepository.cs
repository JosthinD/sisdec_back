using Repositorio.Entities;

namespace Repositorio.Interfaces
{
    public interface IUpusersRepository
    {
        Task<users?> PostAllDataUser(string prinombre, string segnombre, string priapellido, string segapellido, string telefono, string correo, string username, string password);
    }
}

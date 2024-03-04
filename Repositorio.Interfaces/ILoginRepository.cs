using Repositorio.Entities;

namespace Repositorio.Interfaces
{
    public interface ILoginRepository
    {      
        Task<bool> GetExistUser(string email);
        Task<bool> GetCoincidenciaPassword(string email, string password);
        Task<string?> GetRol(string email);
        Task<users?> GetAllDataUser(string email);
    }
}
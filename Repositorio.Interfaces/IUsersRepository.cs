using Repositorio.Entities;

namespace Repositorio.Interfaces
{
    public interface IUsersRepository
    {      
        Task<users?> GetAllDataUser(string email);
    }
}
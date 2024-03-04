using Aplicacion.DTO;
using Repositorio.Entities;

namespace Repositorio.Interfaces
{
    public interface IDataRepository
    {      
        Task<List<Roles>> GetAllRoles();
        Task<bool> AddNewLog(Logs logs);
        Task<List<Generos>> GetAllGenres();
        Task<List<TiposDocumento>> GetAllDocumentTypes();
        Task<List<Estados>> GetAllStates();
    }
}
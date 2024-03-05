using Repositorio.Entities;

namespace Repositorio.Interfaces
{
    public interface ISupportRepository
    {
        Task<List<Soportes>> GetAllSoportes();
        Task<List<Soportes>> GetSoportesByUserId(int userId);
        Task<List<Soportes>> GetSoportesByEstadoId(int estadoId);
        Task<List<Soportes>> GetSoportesByFilters(DateTime? fecha, int? userId, int? estadoId);
        Task<bool> UpdateSoporteEstado(int soporteId, int nuevoEstadoId);
        Task<bool> NewSoporte(Soportes nuevoSoporte);
    }
}
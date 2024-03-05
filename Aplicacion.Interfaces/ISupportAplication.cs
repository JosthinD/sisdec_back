using Aplicacion.DTO;
using Repositorio.Entities;

namespace Aplicacion.Interfaces
{
    public interface ISupportAplication
    {
        Task<ResponseDto<List<Soportes?>>> GetAllSoportes();
        Task<ResponseDto<List<Soportes?>>> GetSoportesByUserId(int userId);
        Task<ResponseDto<List<Soportes?>>> GetSoportesByEstadoId(int estadoId);
        Task<ResponseDto<List<Soportes?>>> GetSoportesByFilters(DateTime? fecha, int? userId, int? estadoId);
        Task<ResponseDto<bool>> UpdateSoporteEstado(int soporteId, int nuevoEstadoId);
        Task<ResponseDto<bool>> NewSoporte(string asunto, string descripcion, int idUsuario);
    }
}

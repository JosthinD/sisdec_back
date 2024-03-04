using Aplicacion.DTO;
using Repositorio.Entities;

namespace Aplicacion.Interfaces
{
    public interface IDataAplication
    {
        Task<ResponseDto<List<Roles?>>> GetAllRoles();
        Task<ResponseDto<List<Generos?>>> GetAllGenres();
        Task<ResponseDto<List<TiposDocumento?>>> GetAllDocumentTypes();
        Task<ResponseDto<List<Estados?>>> GetAllStates();
    }
}

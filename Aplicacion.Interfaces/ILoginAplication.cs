using Aplicacion.DTO;
using Repositorio.Entities;

namespace Aplicacion.Interfaces
{
    public interface ILoginAplication
    {
        Task<ResponseDto<DataLogin>> GetLogin(string email, string password);
    }
}
using Repositorio.Entities;

namespace Repositorio.Interfaces
{
    public interface ISoportRepository
    {
        Task<int> GetAllDataSoport(int idcaso);

    }
}

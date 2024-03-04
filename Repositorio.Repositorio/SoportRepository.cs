using Repositorio.Interfaces;
using Repositorio.Data;
using Microsoft.EntityFrameworkCore;
using Repositorio.Entities;

namespace Repositorio.Repositorio
{
    public class SoportRepository : ISoportRepository
    {
        private readonly DataContext Context;
        public SoportRepository(DataContext context)
        {
            Context = context;
        }
        public async Task<soport?> GetAllDataSoport(int idcaso)
        {
            return await Context.soports.FirstOrDefaultAsync(u => u.idcaso == idcaso);
        }
    }
}

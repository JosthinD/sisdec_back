using Repositorio.Interfaces;
using Repositorio.Data;
using Microsoft.EntityFrameworkCore;
using Repositorio.Entities;
using Aplicacion.DTO;

namespace Repositorio.Repositorio
{
    public class DataRepository : IDataRepository
    {
        private readonly DataContext Context;
        public DataRepository(DataContext context) 
        {
            Context = context;
        }       
        
        public async Task<List<Roles>> GetAllRoles()
        {
            return await Context.Roles.ToListAsync();
        }
    }
}
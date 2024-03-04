using Repositorio.Interfaces;
using Repositorio.Data;
using Microsoft.EntityFrameworkCore;
using Repositorio.Entities;

namespace Repositorio.Repositorio
{
    public class SoportRepository : IUsersRepository
    {
        private readonly DataContext Context;
        public SoportRepository(DataContext context) 
        {
            Context = context;
        }       
        public async Task<users?> GetAllDataUser(string email)
        {
            return await Context.Users.FirstOrDefaultAsync(u => u.correo == email);
        }
    }
}
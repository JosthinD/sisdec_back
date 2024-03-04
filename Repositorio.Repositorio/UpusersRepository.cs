using Repositorio.Interfaces;
using Repositorio.Data;
using Microsoft.EntityFrameworkCore;
using Repositorio.Entities;

namespace Repositorio.Repositorio
{
    public class UpusersRepository : IUpusersRepository
    {
        private readonly DataContext Context;
        public UpusersRepository(DataContext context)
        {
            Context = context;
        }
        public async Task<Upusers?> PostAllDataUser(string email)
        {
            return await Context.Users.FirstOrDefaultAsync(u => u.correo == email);
        }
    }
}

using Repositorio.Interfaces;
using Repositorio.Data;
using Microsoft.EntityFrameworkCore;
using Repositorio.Entities;

namespace Repositorio.Repositorio
{
    public class LoginRepository: ILoginRepository
    {
        private readonly DataContext Context;
        public LoginRepository(DataContext context) 
        {
            Context = context;
        }
        public async Task<bool> GetExistUser(string email)
        {
            return await Context.Users.AnyAsync(u => u.correo == email);
        }
        public async Task<bool> GetCoincidenciaPassword(string email, string password)
        {
            return await Context.Users.AnyAsync(u => u.correo == email && u.password == password);
        }
        public async Task<string?> GetRol(string email)
        {
            return await (from user in Context.Users
                                join r in Context.Roles on user.idrol equals r.IdRol
                                where user.correo == email
                                select r.NomRol).FirstOrDefaultAsync();
        }
        public async Task<users?> GetAllDataUser(string email)
        {
            return await Context.Users.FirstOrDefaultAsync(u => u.correo == email);
        }
    }
}
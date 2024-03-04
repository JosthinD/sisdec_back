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
            return await Context.Usuarios.AnyAsync(u => u.Correo == email);
        }
        public async Task<bool> GetCoincidenciaPassword(string email, string password)
        {
            return await Context.Usuarios.AnyAsync(u => u.Correo == email && u.Contraseña == password);
        }
        public async Task<string?> GetRol(string email)
        {
            return await (from user in Context.Usuarios
                                join r in Context.Roles on user.IdRol equals r.Id
                                where user.Correo == email
                                select r.Rol).FirstOrDefaultAsync();
        }
        public async Task<Usuarios?> GetAllDataUser(string email)
        {
            return await Context.Usuarios.FirstOrDefaultAsync(u => u.Correo == email);
        }
    }
}
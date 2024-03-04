using Repositorio.Interfaces;
using Repositorio.Data;
using Microsoft.EntityFrameworkCore;
using Repositorio.Entities;
using Aplicacion.DTO;

namespace Repositorio.Repositorio
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DataContext Context;
        public UsersRepository(DataContext context) 
        {
            Context = context;
        }       
        public async Task<UsuariosDto?> GetAllDataUser(string email)
        {
            var usuario = await Context.Usuarios.FirstOrDefaultAsync(u => u.Correo == email);

            if (usuario == null)
                return null;

            var usuarioDto = new UsuariosDto
            {
                Id = usuario.Id,
                PrimerNombre = usuario.PrimerNombre,
                SegundoNombre = usuario.SegundoNombre,
                PrimerApellido = usuario.PrimerApellido,
                SegundoApellido = usuario.SegundoApellido,
                TipoDocumento = (await Context.TiposDocumento.FirstOrDefaultAsync(t => t.Id == usuario.IdTipoDocumento))?.TipoDocumento,
                NumeroDocumento = usuario.NumeroDocumento,
                Genero = (await Context.Generos.FirstOrDefaultAsync(g => g.Id == usuario.IdGenero))?.Genero,
                Telefono = usuario.Telefono,
                Correo = usuario.Correo,
                Contraseña = usuario.Contraseña,
                Rol = (await Context.Roles.FirstOrDefaultAsync(r => r.Id == usuario.IdRol))?.Rol,
                Estado = (await Context.Estados.FirstOrDefaultAsync(e => e.Id == usuario.IdEstado))?.Estado
            };

            return usuarioDto;
        }

        public async Task<List<Roles>> GetAllRoles()
        {
            return await Context.Roles.ToListAsync();
        }
    }
}
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
        public async Task<bool> UpdateUserData(UpdateUserDataDto usuarioActualizado)
        {
            var usuario = await Context.Usuarios.FirstOrDefaultAsync(u => u.Id == usuarioActualizado.IdUser);

            if (usuario == null)
                return false; // El usuario no existe

            // Actualizar los datos del usuario, excepto los campos especificados
            usuario.PrimerNombre = usuarioActualizado.PrimerNombre;
            usuario.SegundoNombre = usuarioActualizado.SegundoNombre;
            usuario.PrimerApellido = usuarioActualizado.PrimerApellido;
            usuario.SegundoApellido = usuarioActualizado.SegundoApellido;
            usuario.IdTipoDocumento = usuarioActualizado.IdTipoDocumento;
            usuario.IdGenero = usuarioActualizado.IdGenero;
            usuario.Telefono = usuarioActualizado.Telefono;
            usuario.Correo = usuarioActualizado.Correo;

            await Context.SaveChangesAsync();

            return true; // Actualización exitosa
        }
    }
}
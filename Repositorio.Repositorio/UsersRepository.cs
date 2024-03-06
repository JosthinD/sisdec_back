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
            usuario.Telefono = usuarioActualizado.Telefono;
            usuario.Correo = usuarioActualizado.Correo;

            await Context.SaveChangesAsync();

            return true; // Actualización exitosa
        }
        public async Task<List<UsuariosDto>> GetAllUsers()
        {
            var usuarios = await Context.Usuarios.ToListAsync();
            var tiposDocumento = await Context.TiposDocumento.ToListAsync();
            var generos = await Context.Generos.ToListAsync();
            var roles = await Context.Roles.ToListAsync();
            var estados = await Context.Estados.ToListAsync();

            return usuarios.Select(usuario => new UsuariosDto
            {
                Id = usuario.Id,
                PrimerNombre = usuario.PrimerNombre,
                SegundoNombre = usuario.SegundoNombre,
                PrimerApellido = usuario.PrimerApellido,
                SegundoApellido = usuario.SegundoApellido,
                TipoDocumento = tiposDocumento.FirstOrDefault(t => t.Id == usuario.IdTipoDocumento)?.TipoDocumento,
                NumeroDocumento = usuario.NumeroDocumento,
                Genero = generos.FirstOrDefault(g => g.Id == usuario.IdGenero)?.Genero,
                Telefono = usuario.Telefono,
                Correo = usuario.Correo,
                Contraseña = usuario.Contraseña,
                Rol = roles.FirstOrDefault(r => r.Id == usuario.IdRol)?.Rol,
                Estado = estados.FirstOrDefault(e => e.Id == usuario.IdEstado)?.Estado
            }).ToList();
        }
        public async Task<bool> CreateNewUser(Usuarios newUser)
        {
            try
            {
                // Agregar el nuevo usuario al contexto
                Context.Usuarios.Add(newUser);

                // Guardar los cambios en la base de datos
                await Context.SaveChangesAsync();

                return true; // El usuario se creó correctamente
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción aquí, por ejemplo, registrarla o devolver un mensaje de error
                return false; // Fallo al crear el usuario
            }
        }


        public async Task<bool> VerifyPasswordForUser(int userId, string contraseña)
        {
            // Buscar el usuario por su Id

            var usuario = await Context.Usuarios.FindAsync(userId);

            // Verificar si se encontró el usuario y si la contraseña coincide
            if (usuario != null && usuario.Contraseña == contraseña)
            {
                return true; // La contraseña coincide para el usuario especificado
            }

            return false; // La contraseña no coincide o el usuario no se encontró
        }
        public async Task<bool> UpdateUserPassword(int userId, string nuevaContraseña)
        {
            try
            {
                // Buscar el usuario por su Id
                var usuario = await Context.Usuarios.FindAsync(userId);

                // Verificar si se encontró el usuario
                if (usuario != null)
                {
                    // Actualizar la contraseña del usuario
                    usuario.Contraseña = nuevaContraseña;

                    // Guardar los cambios en la base de datos
                    await Context.SaveChangesAsync();

                    return true; // La contraseña se actualizó correctamente
                }

                return false; // El usuario no se encontró
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción aquí, por ejemplo, registrarla o devolver un mensaje de error
                return false; // Fallo al actualizar la contraseña
            }
        }
        public async Task<bool> UpdateUserState(int userId, int nuevoEstadoId)
        {
            try
            {
                // Buscar el usuario por su Id
                var usuario = await Context.Usuarios.FindAsync(userId);

                // Verificar si se encontró el usuario
                if (usuario != null)
                {
                    // Actualizar el estado del usuario
                    usuario.IdEstado = nuevoEstadoId;

                    // Guardar los cambios en la base de datos
                    await Context.SaveChangesAsync();

                    return true; // El estado del usuario se actualizó correctamente
                }

                return false; // El usuario no se encontró
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción aquí, por ejemplo, registrarla o devolver un mensaje de error
                return false; // Fallo al actualizar el estado del usuario
            }
        }
        public async Task<bool> UpdateUserRole(int userId, int nuevoRolId)
        {
            try
            {
                // Buscar el usuario por su Id
                var usuario = await Context.Usuarios.FindAsync(userId);

                // Verificar si se encontró el usuario
                if (usuario != null)
                {
                    // Actualizar el rol del usuario
                    usuario.IdRol = nuevoRolId;

                    // Guardar los cambios en la base de datos
                    await Context.SaveChangesAsync();

                    return true; // El rol del usuario se actualizó correctamente
                }

                return false; // El usuario no se encontró
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción aquí, por ejemplo, registrarla o devolver un mensaje de error
                return false; // Fallo al actualizar el rol del usuario
            }
        }
    }

}
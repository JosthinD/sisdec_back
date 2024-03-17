using Repositorio.Interfaces;
using Repositorio.Data;
using Microsoft.EntityFrameworkCore;
using Repositorio.Entities;

namespace Repositorio.Repositorio
{
    public class SupportRepository : ISupportRepository
    {
        private readonly DataContext Context;
        public SupportRepository(DataContext context) 
        {
            Context = context;
        }
        public async Task<List<Soportes>> GetAllSoportes()
        {
            return await Context.Soportes.ToListAsync();
        }
        public async Task<List<Soportes>> GetSoportesByUserId(int userId)
        {
            return await Context.Soportes
                .Where(s => s.IdUsuario == userId)
                .ToListAsync();
        }
        public async Task<List<Soportes>> GetSoportesByEstadoId(int estadoId)
        {
            return await Context.Soportes
                .Where(s => s.IdEstado == estadoId)
                .ToListAsync();
        }
        public async Task<List<Soportes>> GetSoportesByFilters(DateTime? fecha, int? userId, int? estadoId)
        {
            var query = Context.Soportes.AsQueryable();

            if (fecha.HasValue)
            {
                var fechaTruncada = fecha.Value.Date;
                query = query.Where(s => s.Fecha.Date == fechaTruncada);
            }

            if (userId.HasValue) query = query.Where(s => s.IdUsuario == userId);

            if (estadoId.HasValue)
                query = query.Where(s => s.IdEstado == estadoId);

            return await query.ToListAsync();
        }
        public async Task<bool> UpdateSoporteEstado(int soporteId, int nuevoEstadoId)
        {
            try
            {
                // Buscar el soporte por su Id
                var soporte = await Context.Soportes.FindAsync(soporteId);

                // Verificar si se encontró el soporte
                if (soporte != null)
                {
                    // Actualizar el estado del soporte
                    soporte.IdEstado = nuevoEstadoId;

                    // Guardar los cambios en la base de datos
                    await Context.SaveChangesAsync();

                    return true; // El estado del soporte se actualizó correctamente
                }

                return false; // El soporte no se encontró
            }
            catch (Exception)
            {
                // Manejar cualquier excepción aquí, por ejemplo, registrarla o devolver un mensaje de error
                return false; // Fallo al actualizar el estado del soporte
            }
        }
        public async Task<bool> NewSoporte(Soportes nuevoSoporte)
        {
            try
            {
                // Agregar el nuevo soporte al DbSet
                Context.Soportes.Add(nuevoSoporte);

                // Guardar los cambios en la base de datos
                await Context.SaveChangesAsync();

                return true; // El soporte se guardó correctamente
            }
            catch (Exception)
            {
                // Manejar cualquier excepción aquí, por ejemplo, registrarla o devolver un mensaje de error
                return false; // Fallo al guardar el soporte
            }
        }
    }
}
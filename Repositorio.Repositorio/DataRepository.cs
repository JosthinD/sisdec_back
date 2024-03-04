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
        public async Task<bool> AddNewLog(Logs logs)
        {
            try
            {
                var nuevoLog = new Logs
                {
                    IdAccion = logs.IdAccion,
                    Descripcion = logs.Descripcion,
                    DateLog = DateTime.Now // O la fecha que desees asignar al log
                };

                Context.Logs.Add(nuevoLog);
                await Context.SaveChangesAsync();

                return true; // El log se agregó correctamente
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción aquí, por ejemplo, registrarla o devolver un mensaje de error
                return false; // Fallo al agregar el log
            }
        }
    }
}
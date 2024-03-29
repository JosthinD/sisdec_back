﻿using Repositorio.Interfaces;
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
        public async Task<List<Generos>> GetAllGenres()
        {
            return await Context.Generos.ToListAsync();
        }
        public async Task<List<TiposDocumento>> GetAllDocumentTypes()
        {
            return await Context.TiposDocumento.ToListAsync();
        }
        public async Task<List<Estados>> GetAllStates()
        {
            return await Context.Estados.ToListAsync();
        }
        public async Task<List<Logs>> GetAllLogs()
        {
            return await Context.Logs.ToListAsync();
        }
        public async Task<List<Logs>> GetLogsByActionIdAndDate(int? idAccion, DateTime? fecha)
        {
            var query = Context.Logs.AsQueryable();

            if (idAccion.HasValue)
            {
                var idAccionValue = idAccion.Value;
                query = query.Where(l => l.IdAccion == idAccionValue);
            }

            if (fecha.HasValue)
            {
                var fechaTruncada = fecha.Value.Date;
                query = query.Where(l => l.DateLog.Date == fechaTruncada);
            }

            return await query.ToListAsync();
        }
    }
}
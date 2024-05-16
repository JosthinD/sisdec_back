using System.Collections.Generic;
using Repositorio.Data;
using Microsoft.EntityFrameworkCore;
using Repositorio.Entities;

namespace Repositorio.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Usuarios>? Usuarios { get; set; }
        public DbSet<Roles>? Roles { get; set; }
        public DbSet<Acciones>? Acciones { get; set; }
        public DbSet<Estados>? Estados { get; set; }
        public DbSet<Generos>? Generos { get; set; }
        public DbSet<Logs>? Logs { get; set; }
        public DbSet<TiposDocumento>? TiposDocumento { get; set; }
        public DbSet<Soportes>? Soportes { get; set; }
        public DbSet<PlanAccionAcademico>? PlanAccionAcademico { get; set; }
        public DbSet<PracticaPorAsignatura>? PracticaPorAsignatura { get; set; }
        public DbSet<AtencionEstudiantes>? AtencionEstudiantes { get; set; }
    }
}
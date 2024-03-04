﻿using System.Collections.Generic;
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
        public DbSet<Usuarios>? Users { get; set; }
        public DbSet<Roles>? Roles { get; set; }
    }
}
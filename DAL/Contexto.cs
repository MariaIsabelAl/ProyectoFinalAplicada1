using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DataVentas.Entidades;

namespace DataVentas.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Vendedores> Vendedores { get; set; }
        public DbSet<Compras> Compras { get; set; }
        public DbSet<Ventas> Ventas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= DATA\DataVentas.db");
        }

       
        
    }
}

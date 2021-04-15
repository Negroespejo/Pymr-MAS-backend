using Microsoft.EntityFrameworkCore;
using Sistema.Datos.Mapping.Almacen;
using Sistema.Entidades.Almacen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos
{
    public class DbContextSistema : DbContext
    {
        // expociocion de todas las categorias 
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Articulo> Articulos { get; set; }

        public DbContextSistema(DbContextOptions<DbContextSistema> options) : base(options)
        {

        }
        //aplicacion de la configuracion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new ArticuloMap());
        }
        
    }
}

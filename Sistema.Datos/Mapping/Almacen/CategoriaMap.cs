using Microsoft.EntityFrameworkCore;
using Sistema.Entidades.Almacen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Almacen
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Categoria> builder)
        {
            //mapemamiento de la entidad categoria con la tabla categoria de la BD usando la endidad categoria
            //referencia a la primary key
            builder.ToTable("Categoria")
                .HasKey(c => c.idcategoria);
            //Propiedades 
            builder.Property(c => c.nombre)
                .HasMaxLength(50);
            builder.Property(c => c.descripcion)
                .HasMaxLength(256);
        }
    }
}

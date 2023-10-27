using Domain.Model.Categorias;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SharedKernel.ValueObjects;
using System.ComponentModel;

namespace Infrastructure.EF.Config.WriteConfig
{
    internal class CategoriaWriteConfig : IEntityTypeConfiguration<Categoria>
    {


        public void Configure(EntityTypeBuilder<Categoria> builder)
        {

            var nombreConverter = new ValueConverter<NombreGeneralValue, string>(
            nombreValue => nombreValue.Name,
            stringValue => new NombreGeneralValue(stringValue)
            );
            var guidConverter = new ValueConverter<GuidVerificadoValue, Guid>(
          guidIdValue => guidIdValue.Id,
           guidValue => new GuidVerificadoValue(guidValue)
          );



            builder.ToTable("Categoria"); // Nombre de la tabla en la base de datos
            builder.HasKey(c => c.Id); // Clave primaria

            builder.Property(c => c.Id).HasColumnName("categoriaId");
            builder.Property(c => c.Nombre).HasColumnName("nombre").HasConversion(nombreConverter);
            builder.Property(c => c.UsuarioId).HasColumnName("usuarioId").HasConversion(guidConverter);


            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }

}

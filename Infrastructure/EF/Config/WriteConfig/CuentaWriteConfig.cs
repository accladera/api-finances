using Domain.Model.Categorias;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

using Domain.Model.Cuentas;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SharedKernel.ValueObjects;

namespace Infrastructure.EF.Config.WriteConfig
{
    internal class CuentaWriteConfig : IEntityTypeConfiguration<Cuenta>
    {


        public void Configure(EntityTypeBuilder<Cuenta> builder)
        {

            var guidConverter = new ValueConverter<GuidVerificadoValue, Guid>(
            guidIdValue => guidIdValue.Id,
             guidValue => new GuidVerificadoValue(guidValue)
            );
            var nombreConverter = new ValueConverter<NombreGeneralValue, string>(
            nombreValue => nombreValue.Name,
            stringValue => new NombreGeneralValue(stringValue)
            );


            builder.ToTable("Cuenta"); // Nombre de la tabla en la base de datos
            
            builder.Property(x => x.Id).HasColumnName("cuentaId");
            builder.Property(c => c.Nombre).HasColumnName("nombre").HasConversion(nombreConverter);
            
            builder.Property(c => c.Saldo).HasColumnName("saldo").HasDefaultValue(0).IsRequired();
            builder.Property(c => c.UsuarioId).HasColumnName("usuarioId").HasConversion(guidConverter);

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);

        }
    }
}

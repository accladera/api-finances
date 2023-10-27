
using Domain.Model.Categorias;
using Domain.Model.Cuentas;
using Domain.Model.Movimientos;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SharedKernel.ValueObjects;
using System.ComponentModel;

namespace Infrastructure.EF.Config.WriteConfig
{
    internal class MovimientoWriteConfig : IEntityTypeConfiguration<Movimiento>
    {
        public void Configure(EntityTypeBuilder<Movimiento> builder)
        {

            var descripcionConverter = new ValueConverter<DescripcionValue, string>(
            descripcionValue => descripcionValue.Descripcion,
            stringValue => new DescripcionValue(stringValue)
            );
            var montoConverter = new ValueConverter<MontoValue, decimal>(
            montoValue => montoValue.Value,
            decimalValue => new MontoValue(decimalValue)
            );

            var guidConverter = new ValueConverter<GuidVerificadoValue, Guid>(
            guidIdValue => guidIdValue.Id,
            guidValue => new GuidVerificadoValue(guidValue)
            ) ;

            var fechaConverter = new ValueConverter<FechaValue, DateTime>(
            fechaValue => fechaValue.Date,
            dateTimeValue => new FechaValue(dateTimeValue)
            );

            var tipoConverter = new ValueConverter<TipoMovimiento, string>(
              stateEnumValue => stateEnumValue.ToString(),
              state => (TipoMovimiento)Enum.Parse(typeof(TipoMovimiento), state)
          );


            builder.ToTable("Movimiento"); 
         
            builder.Property(c => c.Id).HasColumnName("movimientoId");
            builder.Property(c => c.Fecha).HasColumnName("fecha").HasConversion(fechaConverter);
            builder.Property(c => c.Monto).HasColumnName("monto").HasConversion(montoConverter);
            builder.Property(x => x.Tipo).HasColumnName("tipo").HasConversion(tipoConverter);
            builder.Property(c => c.Descripcion).HasColumnName("descripcion").HasConversion(descripcionConverter);
            builder.Property(c => c.CuentaId).HasColumnName("cuentaId").HasConversion(guidConverter);
            builder.Property(c => c.CategoriaId).HasColumnName("categoriaId").HasConversion(guidConverter);
            builder.Property(c => c.UsuarioId).HasColumnName("usuarioId").HasConversion(guidConverter);

            // builder.Property("_domainEvents");
            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}

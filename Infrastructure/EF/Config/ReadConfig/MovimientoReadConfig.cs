using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Infrastructure.EF.ReadModel;

namespace Infrastructure.EF.Config.ReadConfig
{
    internal class MovimientoReadConfig : IEntityTypeConfiguration<MovimientoReadModel>
    {
        public void Configure(EntityTypeBuilder<MovimientoReadModel> builder)
        {
            builder.ToTable("Movimiento");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("movimientoId");

            builder.Property(c => c.Tipo).HasColumnName("tipo").IsRequired();

            builder.Property(c => c.Monto).HasColumnName("monto")
                .IsRequired()
                .HasPrecision(14, 2)
                .HasDefaultValue(0);

            builder.Property(c => c.Fecha).HasColumnName("fecha")
                .HasDefaultValue(DateTime.Now);

            builder.Property(c => c.Descripcion).HasColumnName("descripcion")
                 .HasMaxLength(150);

            builder.Property(c => c.CuentaId).HasColumnName("cuentaId");
            builder.HasOne(c => c.Cuenta)
            .WithMany()
            .HasForeignKey(c => c.CuentaId)
            .OnDelete(DeleteBehavior.Restrict);


            builder.Property(c => c.CategoriaId).HasColumnName("categoriaId");
            builder.HasOne(c => c.Categoria)
       .WithMany()
       .HasForeignKey(c => c.CategoriaId)
       .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.UsuarioId).HasColumnName("usuarioId");
            builder.HasOne(c => c.Usuario)
            .WithMany()
            .HasForeignKey(c => c.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);

         


        }
    }
}

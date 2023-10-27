using Infrastructure.EF.ReadModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Config.ReadConfig
{
    public class CuentaReadConfig : IEntityTypeConfiguration<CuentaReadModel>
    {
        public void Configure(EntityTypeBuilder<CuentaReadModel> builder)
        {
            builder.ToTable("Cuenta");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("cuentaId");
            builder.Property(c => c.Nombre).HasColumnName("nombre")
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(c => c.Saldo).HasColumnName("saldo")
                .HasPrecision(14, 2)
                .HasDefaultValue(0);
            builder.Property(c => c.UsuarioId).HasColumnName("usuarioId");
            builder.HasOne(c => c.Usuario).WithMany()
                .HasForeignKey(c => c.UsuarioId);

        }
    }
}

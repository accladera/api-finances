using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Infrastructure.EF.ReadModel;

namespace Infrastructure.EF.Config.ReadConfig
{
    internal class UsuarioReadConfig : IEntityTypeConfiguration<UsuarioReadModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioReadModel> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("usuarioId");

            builder.Property(c => c.Email).HasColumnName("email")
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(c => c.Password).HasColumnName("password")
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(c => c.SaldoTotal).HasColumnName("saldoTotal")
               .HasPrecision(14, 2)
               .HasDefaultValue(0);

        }
    }
}

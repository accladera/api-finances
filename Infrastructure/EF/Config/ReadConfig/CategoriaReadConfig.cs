using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Infrastructure.EF.ReadModel;

namespace Infrastructure.EF.Config.ReadConfig
{
    public class CategoriaReadConfig : IEntityTypeConfiguration<CategoriaReadModel>
    {
        public void Configure(EntityTypeBuilder<CategoriaReadModel> builder)
        {
            builder.ToTable("Categoria");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasColumnName("categoriaId");

            builder.Property(c => c.Nombre).HasColumnName("nombre")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(c => c.UsuarioId).HasColumnName("usuarioId");
            builder.HasOne(c => c.Usuario).WithMany()
                .HasForeignKey(c => c.UsuarioId);

        }
    }
}

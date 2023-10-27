
using Domain.Model.Usuarios;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.EF.Config.WriteConfig
{
    public class UsuarioWriteConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {

            var emailConverter = new ValueConverter<EmailValue, string>(
              emailValue => emailValue.Email,
              stringValue => new EmailValue(stringValue)
          );

            var passwordConverter = new ValueConverter<UserPasswordValue, string>(
              passwordValue => passwordValue.Password,
              stringValue => new UserPasswordValue(stringValue)
          );
            builder.ToTable("Usuario");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("usuarioId");
            builder.Property(x => x.Email).HasColumnName("Email").HasConversion(emailConverter);
            builder.Property(x => x.Password).HasColumnName("Password").HasConversion(passwordConverter);
            builder.Property(x => x.SaldoTotal).HasColumnName("SaldoTotal").HasPrecision(38, 2);

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}

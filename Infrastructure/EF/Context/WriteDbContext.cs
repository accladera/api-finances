using Domain.Model.Categorias;
using Domain.Model.Cuentas;
using Domain.Model.Movimientos;
using Domain.Model.Usuarios;
using Infrastructure.EF.Config.ReadConfig;
using Infrastructure.EF.Config.WriteConfig;
using Infrastructure.EF.ReadModel;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Core;

namespace Infrastructure.EF.Context
{
    internal class WriteDbContext : DbContext
    {
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet< Categoria> Categorias { get; set; }
        public virtual DbSet<Cuenta> Cuentas { get; set; }
        public virtual DbSet<Movimiento> Movimientos { get; set; }
        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration<Usuario>(new UsuarioWriteConfig());
            modelBuilder.ApplyConfiguration<Cuenta>(new CuentaWriteConfig());
            modelBuilder.ApplyConfiguration<Categoria>(new CategoriaWriteConfig());
            modelBuilder.ApplyConfiguration<Movimiento>(new MovimientoWriteConfig());

            modelBuilder.Ignore<DomainEvent>();
            //modelBuilder.Ignore<TransaccionConfirmada>();
        }



    }
}

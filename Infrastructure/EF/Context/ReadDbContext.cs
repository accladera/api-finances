using Infrastructure.EF.Config.ReadConfig;
using Infrastructure.EF.ReadModel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EF.Context
{
    public class ReadDbContext : DbContext
    {
        public virtual DbSet<UsuarioReadModel> Usuarios { get; set; }
        public virtual DbSet<CategoriaReadModel> Categorias { get; set; }
        public virtual DbSet<CuentaReadModel> Cuentas { get; set; }
        public virtual DbSet<MovimientoReadModel> Movimientos { get; set; }

        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration<UsuarioReadModel>(new UsuarioReadConfig());
            modelBuilder.ApplyConfiguration<CategoriaReadModel>(new CategoriaReadConfig());
            modelBuilder.ApplyConfiguration<CuentaReadModel>(new CuentaReadConfig());
            modelBuilder.ApplyConfiguration<MovimientoReadModel>(new MovimientoReadConfig());

         
        }
    }
}

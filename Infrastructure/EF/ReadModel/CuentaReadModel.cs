using System.ComponentModel.DataAnnotations;

namespace Infrastructure.EF.ReadModel
{
    public class CuentaReadModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public decimal Saldo { get; set; }
        public Guid UsuarioId { get; set; }
        public UsuarioReadModel Usuario { get; set; }
    }
}

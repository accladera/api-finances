using System.ComponentModel.DataAnnotations;

namespace Infrastructure.EF.ReadModel
{
    public class UsuarioReadModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal SaldoTotal { get; set; }
    }
}

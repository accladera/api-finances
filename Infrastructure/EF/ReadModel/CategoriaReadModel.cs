using System.ComponentModel.DataAnnotations;

namespace Infrastructure.EF.ReadModel
{
    public class CategoriaReadModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public Guid UsuarioId { get; set; }
        public UsuarioReadModel Usuario { get; set; }
    }
}

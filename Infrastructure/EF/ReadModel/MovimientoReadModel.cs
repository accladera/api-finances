using System.ComponentModel.DataAnnotations;

namespace Infrastructure.EF.ReadModel
{
    public class MovimientoReadModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Tipo { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public CuentaReadModel Cuenta { get; set; }
        public Guid CuentaId { get; set; }
        public CategoriaReadModel Categoria { get; set; }
        public Guid CategoriaId { get; set; }
        
        public Guid UsuarioId { get; set; }
        public UsuarioReadModel Usuario { get; set; }



    }
}

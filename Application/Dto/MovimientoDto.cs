

using SharedKernel.ValueObjects;

namespace Application.Dto
{
    public class MovimientoDto
    {
        public Guid Id { get; set; }
        public int Tipo { get;  set; }
        public decimal Monto { get;  set; }
        public DateTime Fecha { get;  set; }
        public string Descripcion { get;  set; }
        public Guid CuentaId { get;  set; }
        public Guid CategoriaId { get;  set; }
        public string Cuenta { get; set; }
        public string Categoria { get; set; }

    }
}

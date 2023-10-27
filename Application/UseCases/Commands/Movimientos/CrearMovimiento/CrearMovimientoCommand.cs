using MediatR;

namespace Application.UseCases.Commands.Movimientos.CrearMovimiento
{
    public class CrearMovimientoCommand : IRequest<Guid>
    {
        public Guid UsuarioId { get; set; }
        public Guid CuentaId { get; set; }
        public Guid CategoriaId { get; set; }
        public Guid MovimientoRef { get; set; }

        public int Tipo { get; set; }

        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public CrearMovimientoCommand(Guid usuarioId, Guid cuentaId, Guid categoriaId, int tipo, DateTime fecha, string descripcion, decimal monto, Guid movimientoRef)
        {
            UsuarioId = usuarioId;
            CuentaId = cuentaId;
            CategoriaId = categoriaId;
            Tipo = tipo;
            Fecha = fecha;
            Descripcion = descripcion;
            Monto = monto;
            MovimientoRef = movimientoRef;
        }

    }
}

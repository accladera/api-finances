
using Domain.Model.Movimientos;

namespace Domain.Factories.Movimientos
{
    public interface IMovimientoFactory
    {
        public Movimiento CrearMovimiento(
            DateTime fecha, string descripcion, int tipo,
            Guid usuarioId, Guid cuentaId, Guid categoriaId,
            decimal monto, decimal saldo);
    }
}

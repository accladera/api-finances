using Domain.Event;
using Domain.Model.Movimientos;

namespace Domain.Factories.Movimientos
{
   
    public class MovimientoFactory : IMovimientoFactory
    {
        public Movimiento CrearMovimiento(
            DateTime fecha, string descripcion, int tipo,
            Guid usuarioId, Guid cuentaId, Guid categoriaId,
            decimal monto, decimal saldo)
        {
            var tipoMovimiento = (tipo == 1) ? TipoMovimiento.Egreso : TipoMovimiento.Ingreso;
            if (tipoMovimiento == TipoMovimiento.Egreso)
            {
                if (saldo < monto) throw new InvalidOperationException("No tienes suficiente saldo para realizar la operación.");
            }
            return new Movimiento(tipoMovimiento, fecha,descripcion,monto,usuarioId,cuentaId,categoriaId);

        }
     
    }
}

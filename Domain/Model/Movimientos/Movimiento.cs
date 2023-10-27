
using Domain.Event;
using Domain.ValueObjects;
using SharedKernel.Core;
using SharedKernel.ValueObjects;

namespace Domain.Model.Movimientos
{
    public class Movimiento : AggregateRoot<Guid>
    {
        public TipoMovimiento Tipo { get; private set; }
        public MontoValue Monto { get; private set; }
        public FechaValue Fecha { get; private set; }
        public DescripcionValue Descripcion { get; private set; }
        public GuidVerificadoValue UsuarioId { get; private set; }
        public GuidVerificadoValue CuentaId { get; private set; }
       // public Guid CuentaId { get; private set; }
        public GuidVerificadoValue CategoriaId { get; private set; }



        public Movimiento(TipoMovimiento tipo, DateTime fecha, string descripcion, decimal monto, Guid usuarioId, Guid cuentaId, Guid categoriaId)
        {
            Tipo = tipo;
            Fecha = fecha;
            Descripcion = descripcion;
            Monto = monto;
            UsuarioId = usuarioId;
            CuentaId = cuentaId;
            CategoriaId = categoriaId;
            Id = Guid.NewGuid();
            ModificarSaldoDeCuenta(Monto, Tipo);
        }

        protected Movimiento() { }


        public void ActualizarMovimiento(DateTime fecha, string descripcion, Guid categoriaId, TipoMovimiento tipo, decimal monto)
        {
            Fecha = fecha;
            Descripcion = descripcion;
            CategoriaId = categoriaId;
            Monto = monto;
            if(tipo==TipoMovimiento.Ingreso)
            {
                decimal montoTotal = Monto + monto;
                ModificarSaldoDeCuenta(montoTotal, Tipo);
            }
            else
            {
                decimal montoTotal = Monto - monto;
                ModificarSaldoDeCuenta(montoTotal, Tipo);
            }
              
          
        }
        public void EliminarMovimiento()
        {
            ModificarSaldoDeCuenta(Monto, Tipo);
        }

        public void ModificarSaldoDeCuenta(decimal monto, TipoMovimiento tipoMovimiento)
        {
            AddDomainEvent(new SaldoDeCuentaActualizado(CuentaId, monto, tipoMovimiento, DateTime.Now));
        }
    }
}

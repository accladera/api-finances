using Domain.Event;
using Domain.Model.Movimientos;
using Domain.ValueObjects;
using SharedKernel.Core;
using SharedKernel.ValueObjects;

namespace Domain.Model.Cuentas
{
    public class Cuenta : AggregateRoot<Guid>
    {
        public GuidVerificadoValue UsuarioId { get; private set; }

        public NombreGeneralValue Nombre { get; private set; }

        public decimal Saldo { get; private set; }

        public Cuenta(Guid usuarioId, string nombre, decimal saldo)
        {

            UsuarioId = usuarioId;
            Nombre = nombre;
            Saldo = saldo;
            Id = Guid.NewGuid();
        }

        protected Cuenta() { }


       

        public void EditarCuenta(string nombre, decimal saldo)
        {
            Nombre = nombre;
            Saldo = saldo;
        }

        public void ActualizarSaldo(decimal monto, TipoMovimiento tipoMovimiento)
        {
            if (tipoMovimiento == TipoMovimiento.Ingreso)
            {
                Saldo += monto;
            }
            else
            {
                Saldo -= monto;
            }

        }

        public void EliminarCuenta()
        {
            AddDomainEvent(new CuentaRemovida(Id, DateTime.Now));
        }






    }
}

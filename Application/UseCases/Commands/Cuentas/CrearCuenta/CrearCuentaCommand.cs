
using MediatR;

namespace Application.UseCases.Commands.Cuentas.CrearCuenta
{
    public class CrearCuentaCommand : IRequest<Guid>
    {
        public Guid PropietarioId { get;  set; }
        public string   Nombre { get;  set; }
        public decimal Saldo { get;  set; }
        public CrearCuentaCommand( Guid propietarioId, string nombre, decimal saldo)
        {
            PropietarioId = propietarioId;
            Nombre = nombre;
            Saldo = saldo;
        }

    }
}

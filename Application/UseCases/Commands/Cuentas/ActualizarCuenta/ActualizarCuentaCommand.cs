using MediatR;

namespace Application.UseCases.Commands.Cuentas.ActualizarCuenta
{
    public class ActualizarCuentaCommand : IRequest<Guid>
    {

        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public decimal Saldo { get; set; }

        public ActualizarCuentaCommand(Guid id, string nombre, decimal saldo)
        {
            Id = id;
            Nombre = nombre;
            Saldo = saldo;
        }
    }
}


using MediatR;

namespace Application.UseCases.Commands.Cuentas.EliminarCuenta
{
  
    public class EliminarCuentaCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public EliminarCuentaCommand(Guid id)
        {
            Id = id;
        }
    }
}

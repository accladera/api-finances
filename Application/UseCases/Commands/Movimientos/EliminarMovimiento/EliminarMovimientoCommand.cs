using MediatR;

namespace Application.UseCases.Commands.Movimientos.EliminarMovimiento
{
  

    public class EliminarMovimientoCommand : IRequest<bool>
    {
    
        public Guid Id { get; set; }


        public EliminarMovimientoCommand(Guid id)
        {
            Id = id;
        }

    }
}

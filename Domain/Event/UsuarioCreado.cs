using Domain.Model.Movimientos;
using SharedKernel.Core;


namespace Domain.Event
{
    public record UsuarioCreado : DomainEvent
    {
        public Guid UsuarioId { get; set; }

        public UsuarioCreado(Guid usuarioId, DateTime occuredOn) : base(occuredOn)
        {
            UsuarioId = usuarioId;
        }
    }
}

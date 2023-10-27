using Application.Dto;
using MediatR;

namespace Application.UseCases.Query.Movimientos.GetMovimientosByUserId
{
    public class GetMovimientosByUserIdQuery : IRequest<ICollection<MovimientoDto>>
    {
        public Guid UsuarioId { get; set; }
        public GetMovimientosByUserIdQuery(Guid usuarioId)
        {
            UsuarioId = usuarioId;
        }
    }
}

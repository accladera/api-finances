

using Application.Dto;
using MediatR;

namespace Application.UseCases.Query.Cuentas.GetCuentasByUserId
{
    public class GetCuentasByUserIdQuery : IRequest<ICollection<CuentaDto>>
    {
        public Guid UsuarioId { get; set; }

        public GetCuentasByUserIdQuery(Guid usuarioId)
        {
            UsuarioId = usuarioId;
        }
    }

}

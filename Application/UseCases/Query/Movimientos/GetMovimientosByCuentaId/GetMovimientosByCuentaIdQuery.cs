
using Application.Dto;
using MediatR;

namespace Application.UseCases.Query.Movimientos.GetMovimientosByCuentaId
{
    public class GetMovimientosByCuentaIdQuery : IRequest<ICollection<MovimientoDto>>
    {
        public Guid CuentaId { get; set; }
        public GetMovimientosByCuentaIdQuery(Guid cuentaId)
        {
            CuentaId = cuentaId;
        }
    }
}

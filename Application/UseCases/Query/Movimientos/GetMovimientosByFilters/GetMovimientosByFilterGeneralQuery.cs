
using Application.Dto;
using Domain.Model.Usuarios;
using MediatR;

namespace Application.UseCases.Query.Movimientos.GetMovimientosByFilters
{


    public class GetMovimientosByFilterGeneralQuery : IRequest<ICollection<MovimientoDto>>
    {
        public Guid UsuarioId { get; set; }
        public Guid? CuentaId { get; set; }
        public Guid? CategoriaId { get; set; }
        public string? FechaDesde { get; set; }
        public string? FechaHasta { get; set; }

    }

}

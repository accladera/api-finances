
using Application.Dto;
using MediatR;

namespace Application.UseCases.Query.Movimientos.GetMovimientosByFilters
{
    
    public class GetMovimientosByFilterMonthQuery : IRequest<ICollection<MovimientoDto>>
    {
        public int Mes { get; set; }
        public int Anho { get; set; }
        public GetMovimientosByFilterMonthQuery(int mes, int anho)
        {
            Mes = mes;
            Anho = anho;
        }
    }
}

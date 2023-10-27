using Application.Dto;
using MediatR;

namespace Application.UseCases.Query.Movimientos.GetBalanceByMonth
{
    

    public class GetBalanceByMonthQuery : IRequest<BalanceDto>
    {
        public int Mes { get; set; }
        public int Anho { get; set; }
        public Guid UsuarioId { get; set; }
        public string? FechaDesde { get; set; }
        public string? FechaHasta { get; set; }
      

    }
}

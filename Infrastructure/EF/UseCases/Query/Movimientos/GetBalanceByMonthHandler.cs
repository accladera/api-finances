using Application.Dto;
using Application.UseCases.Query.Movimientos.GetBalanceByMonth;
using Infrastructure.EF.Context;
using Infrastructure.EF.ReadModel;
using Infrastructure.EF.UseCases.Query.Movimientos.mappers;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.EF.UseCases.Query.Movimientos
{



    public class GetBalanceByMonthHandler : IRequestHandler<GetBalanceByMonthQuery, BalanceDto>
    {
        private readonly DbSet<MovimientoReadModel> _movimientoDbSet;

        public GetBalanceByMonthHandler(ReadDbContext context)
        {
            _movimientoDbSet = context.Movimientos;
        }

        public async Task<BalanceDto> Handle(GetBalanceByMonthQuery request, CancellationToken cancellationToken)
        {


            var query = _movimientoDbSet
             .AsNoTracking()
             .Include(x => x.Categoria)
             .Include(x => x.Cuenta)
             .Include(x => x.Usuario)
             .Where(x => x.UsuarioId == request.UsuarioId).AsQueryable();

            if (request.FechaDesde != null && request.FechaHasta != null)
            {
                query = FiltrarPorFecha(query, request.FechaDesde, request.FechaHasta);
            }

            query = query.OrderBy(x => x.Fecha);

            var list = await query.ToListAsync();


            decimal ingresoTotal = 0;
            decimal egresoTotal = 0;
          
            foreach (var item in list)
            {
                if(EnumTipoMapper.enumTipoMapper(item.Tipo) == 0)
                {
                    ingresoTotal = ingresoTotal + item.Monto;
                }
                else
                {
                    if (EnumTipoMapper.enumTipoMapper(item.Tipo) == 1)
                    {
                        egresoTotal= egresoTotal+item.Monto;
                    }
                }
                }
            var resultado = new BalanceDto()
            {
                totalEgreso = egresoTotal,
                totalIngreso = ingresoTotal
            }; 
          


            return resultado;
        }



        private IQueryable<MovimientoReadModel> FiltrarPorFecha(IQueryable<MovimientoReadModel> query, string? fechaDesde, string? fechaHasta)
        {
            if (DateTime.TryParse(fechaDesde, out var fechaDesdeValue))
            {
                query = query.Where(x => x.Fecha.Date >= fechaDesdeValue.Date);
            }

            if (DateTime.TryParse(fechaHasta, out var fechaHastaValue))
            {
                query = query.Where(x => x.Fecha.Date <= fechaHastaValue.Date);
            }

            return query;
        }




    }



}

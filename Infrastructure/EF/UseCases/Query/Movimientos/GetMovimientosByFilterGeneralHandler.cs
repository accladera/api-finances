using Application.Dto;
using Application.UseCases.Query.Movimientos.GetMovimientosByFilters;
using Domain.Model.Categorias;
using Infrastructure.EF.Context;
using Infrastructure.EF.ReadModel;
using Infrastructure.EF.UseCases.Query.Movimientos.mappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EF.UseCases.Query.Movimientos
{


    public class GetMovimientosByFilterGeneralHandler : IRequestHandler<GetMovimientosByFilterGeneralQuery, ICollection<MovimientoDto>>
    {
        private readonly DbSet<MovimientoReadModel> _movimientoDbSet;

        public GetMovimientosByFilterGeneralHandler(ReadDbContext context)
        {
            _movimientoDbSet = context.Movimientos;
        }

        public async Task<ICollection<MovimientoDto>> Handle(GetMovimientosByFilterGeneralQuery request, CancellationToken cancellationToken)
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
            if( request.CuentaId != null)
            {
                query = FiltrarPorCuenta(query, request.CuentaId);
            }
            if( request.CategoriaId != null)
            {
                query = FiltrarPorCategoria(query, request.CategoriaId);
            }
            query= query.OrderBy(x => x.Fecha);


            var list = await query.ToListAsync();

            var resultado = new List<MovimientoDto>();
            foreach (var item in list)
            {
                var objDto = new MovimientoDto()
                {
                    Id = item.Id,
                    Monto = item.Monto,
                    Tipo = EnumTipoMapper.enumTipoMapper(item.Tipo),
                    Descripcion = item.Descripcion,
                    Fecha = item.Fecha,
                    CategoriaId = item.CategoriaId,
                    CuentaId = item.CuentaId,
                    Cuenta = item.Cuenta.Nombre,
                    Categoria = item.Categoria.Nombre,
                };
                resultado.Add(objDto);
            }

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


        private IQueryable<MovimientoReadModel> FiltrarPorCuenta(IQueryable<MovimientoReadModel> query, Guid? cuentaId)
        {
            if (cuentaId != Guid.Empty && !string.IsNullOrEmpty(cuentaId.ToString()))
            {
                Console.WriteLine("FiltrarPorCuenta");
                query = query.Where(x => x.CuentaId == cuentaId);
            }
            return query;
        }
        private IQueryable<MovimientoReadModel> FiltrarPorCategoria(IQueryable<MovimientoReadModel> query, Guid? categoriaId)
        {
            if (categoriaId != Guid.Empty && !string.IsNullOrEmpty(categoriaId.ToString()))
            {
                query = query.Where(x => x.CategoriaId == categoriaId);
            }
            return query;
        }

    }
}

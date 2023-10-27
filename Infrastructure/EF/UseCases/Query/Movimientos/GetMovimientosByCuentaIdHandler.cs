using Application.Dto;
using Application.UseCases.Query.Movimientos.GetMovimientosByCuentaId;
using Infrastructure.EF.Context;
using Infrastructure.EF.ReadModel;
using Infrastructure.EF.UseCases.Query.Movimientos.mappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EF.UseCases.Query.Movimientos
{

    public class GetMovimientosByCuentaIdHandler : IRequestHandler<GetMovimientosByCuentaIdQuery, ICollection<MovimientoDto>>
    {
        private readonly DbSet<MovimientoReadModel> _movimientoDbSet;

        public GetMovimientosByCuentaIdHandler(ReadDbContext context)
        {
            _movimientoDbSet = context.Movimientos;
        }

        public async Task<ICollection<MovimientoDto>> Handle(GetMovimientosByCuentaIdQuery request, CancellationToken cancellationToken)
        {


            var list = await _movimientoDbSet
                .AsNoTracking()
                .Include(x => x.Categoria)
                .Include(x => x.Cuenta)
                .Include(x => x.Usuario)
                .Where(x => x.CuentaId == request.CuentaId)
                .OrderBy(x => x.Fecha)
                .ToListAsync();
            var resultado = new List<MovimientoDto>();
            foreach (var item in list)
            {
                var objDto = new MovimientoDto()
                {
                    Id = item.Id,
                    Monto = item.Monto,
                    Tipo = EnumTipoMapper.enumTipoMapper(item.Tipo),
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
    }
}

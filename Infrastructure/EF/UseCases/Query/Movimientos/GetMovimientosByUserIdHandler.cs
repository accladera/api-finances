
using Application.Dto;
using Application.UseCases.Query.Movimientos.GetMovimientosByUserId;
using Infrastructure.EF.Context;
using Infrastructure.EF.ReadModel;
using Infrastructure.EF.UseCases.Query.Movimientos.mappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EF.UseCases.Query.Movimientos
{
    public class GetMovimientosByUserIdHandler : IRequestHandler<GetMovimientosByUserIdQuery, ICollection<MovimientoDto>>
    {
        private readonly DbSet<MovimientoReadModel> _movimientoDbSet;

        public GetMovimientosByUserIdHandler(ReadDbContext context)
        {
            _movimientoDbSet = context.Movimientos;
        }

        public async Task<ICollection<MovimientoDto>> Handle(GetMovimientosByUserIdQuery request, CancellationToken cancellationToken)
        {

            var list = await _movimientoDbSet
                .AsNoTracking()
                .Include(x => x.Categoria)
                .Include(x => x.Cuenta)
                .Include(x => x.Usuario)
                .Where(x => x.UsuarioId == request.UsuarioId)
                .OrderBy(x=> x.Fecha)
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
                    Descripcion= item.Descripcion,
                    CategoriaId = item.CategoriaId,
                    CuentaId = item.CuentaId,
                    Cuenta = item.Cuenta.Nombre,
                    Categoria= item.Categoria.Nombre,
                };
                resultado.Add(objDto);
            }

            return resultado;
        }
    }
}

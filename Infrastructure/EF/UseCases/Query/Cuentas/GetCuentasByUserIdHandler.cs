
using Application.Dto;
using Application.UseCases.Query.Cuentas.GetCuentasByUserId;
using Infrastructure.EF.Context;
using Infrastructure.EF.ReadModel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EF.UseCases.Query.Cuentas
{
    public class GetCuentasByUserIdHandler : IRequestHandler<GetCuentasByUserIdQuery, ICollection<CuentaDto>>
    {
        private readonly DbSet<CuentaReadModel> _cuentaDbSet;

        public GetCuentasByUserIdHandler(ReadDbContext context)
        {
            _cuentaDbSet = context.Cuentas;
        }

        public async Task<ICollection<CuentaDto>> Handle(GetCuentasByUserIdQuery request, CancellationToken cancellationToken)
        {

            var list = await _cuentaDbSet
                .AsNoTracking()
                .Include(x => x.Usuario)
                .Where(x => x.UsuarioId == request.UsuarioId)
                .ToListAsync(cancellationToken);

            var resultado = new List<CuentaDto>();
            foreach (var item in list)
            {
                var objDto = new CuentaDto()
                {
                    Id = item.Id,
                    Nombre = item.Nombre,
                    Saldo = item.Saldo,
                };
                resultado.Add(objDto);
            }

            return resultado;
        }
    }

}

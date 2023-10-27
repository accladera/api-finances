
using Application.Dto;
using Application.UseCases.Query.Categorias.GetCategoriasByUserId;
using Infrastructure.EF.Context;
using Infrastructure.EF.ReadModel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EF.UseCases.Query.Categorias
{
    public class GetCategoriasByUserIdHandler : IRequestHandler<GetCategoriasByUserIdQuery, ICollection<CategoriaDto>>
    {
        private readonly DbSet<CategoriaReadModel> _categoriaDbSet;

        public GetCategoriasByUserIdHandler(ReadDbContext context)
        {
            _categoriaDbSet = context.Categorias;
        }

        public async Task<ICollection<CategoriaDto>> Handle(GetCategoriasByUserIdQuery request, CancellationToken cancellationToken)
        {

            var categorias = await _categoriaDbSet
                .AsNoTracking()
                .Include(x => x.Usuario)
                .Where(x => x.UsuarioId == request.UsuarioId)
                .ToListAsync(cancellationToken);


            var resultado = new List<CategoriaDto>();
            foreach (var item in categorias)
            {
                var categoriaDto = new CategoriaDto()
                {
                    Id = item.Id,
                    Nombre = item.Nombre,
                };
                resultado.Add(categoriaDto);
            }

            return resultado;
        }
    }
}


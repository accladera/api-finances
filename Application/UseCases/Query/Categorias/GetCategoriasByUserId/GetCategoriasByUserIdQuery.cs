using Application.Dto;
using MediatR;

namespace Application.UseCases.Query.Categorias.GetCategoriasByUserId
{
    public class GetCategoriasByUserIdQuery : IRequest<ICollection<CategoriaDto>>
    {
        public Guid UsuarioId { get; set; }

        public GetCategoriasByUserIdQuery(Guid usuarioId)
        {
            UsuarioId = usuarioId;
        }
    }
}

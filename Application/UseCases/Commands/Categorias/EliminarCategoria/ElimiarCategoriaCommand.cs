using MediatR;

namespace Application.UseCases.Commands.Categorias.EliminarCategoria
{
    public class ElimiarCategoriaCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        
        public ElimiarCategoriaCommand(Guid id)
        {
            Id = id;
        }
    }
}

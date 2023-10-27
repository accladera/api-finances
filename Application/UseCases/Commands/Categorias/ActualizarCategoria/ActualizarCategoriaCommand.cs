using MediatR;

namespace Application.UseCases.Commands.Categorias.ActualizarCategoria
{
    public record ActualizarCategoriaCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }

        public ActualizarCategoriaCommand(Guid id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
    }
}

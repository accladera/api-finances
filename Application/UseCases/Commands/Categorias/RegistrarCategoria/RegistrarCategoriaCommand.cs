using MediatR;

namespace Application.UseCases.Commands.Categorias.RegistrarCategoria
{
    public record RegistrarCategoriaCommand : IRequest<Guid>
    {
        public Guid PropietarioId { get; set; }
        public string Nombre { get; set; }

        public RegistrarCategoriaCommand(Guid propietarioId, string nombre)
        {
            PropietarioId = propietarioId;
            Nombre = nombre;
        }
    }
}

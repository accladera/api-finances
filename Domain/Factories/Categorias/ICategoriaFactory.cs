using Domain.Model.Categorias;

namespace Domain.Factories.Categorias
{
    public interface ICategoriaFactory
    {
        Categoria Create(string nombre, Guid usuarioId);
    }
}

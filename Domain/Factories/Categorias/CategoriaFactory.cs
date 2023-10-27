
using Domain.Model.Categorias;

namespace Domain.Factories.Categorias
{
    public class CategoriaFactory : ICategoriaFactory
    {
       public Categoria Create(string nombre, Guid usuarioId)
        {
            var obj = new Categoria(nombre, usuarioId);
            return obj;
        }
    }
}

using Domain.Model.Categorias;
using Domain.Model.Usuarios;
using SharedKernel.Core;

namespace Domain.Repositories
{
    public interface ICategoriaRepository : IRepository<Categoria, Guid>
    {
        Task UpdateAsync(Categoria categoria);
        Task RemoveAsync(Categoria obj);
        Task Add(Categoria obj);
       // Task FindDefault();
    }
}

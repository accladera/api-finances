using Domain.Model.Movimientos;
using SharedKernel.Core;

namespace Domain.Repositories
{
    public interface IMovimientoRepository : IRepository<Movimiento, Guid>
    {
        Task UpdateAsync(Movimiento movimiento);
        Task RemoveAsync(Movimiento obj);
        Task<ICollection<Movimiento>> GetAll();
        Task<ICollection<Movimiento>> GetAllByCategoria(Guid categoriaId);
        Task RemoveAllByCuentaId(Guid cuentaId);



    }
}

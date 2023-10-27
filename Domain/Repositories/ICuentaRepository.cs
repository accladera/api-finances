using Domain.Model.Cuentas;
using SharedKernel.Core;

namespace Domain.Repositories
{
    public interface ICuentaRepository : IRepository<Cuenta, Guid>
    {
        Task UpdateAsync(Cuenta obj);
        Task RemoveAsync(Cuenta obj);


    }
}

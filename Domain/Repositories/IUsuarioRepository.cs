using Domain.Model.Usuarios;
using SharedKernel.Core;

namespace Domain.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario, Guid>
    {
        Task UpdateAsync(Usuario usuario);
        Task RemoveAsync(Usuario usuario);
        Task<Usuario> FindByEmailAsync(string email);


    }
}

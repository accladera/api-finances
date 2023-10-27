
using Domain.Model.Usuarios;

namespace Domain.Factories.Usuarios
{
    public interface IUsuarioFactory
    {
        Usuario Create(string email, string password);
    }
}

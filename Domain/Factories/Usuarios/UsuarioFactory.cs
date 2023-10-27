
using Domain.Model.Usuarios;

namespace Domain.Factories.Usuarios
{
    public class UsuarioFactory : IUsuarioFactory
    {
        public Usuario Create(string email, string password)
        {
            var obj = new Usuario(email, password);
            return obj;

        }
    }
}

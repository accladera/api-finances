using MediatR;

namespace Application.UseCases.Commands.Usuarios.RegistrarUsuario
{
    public record RegistrarUsuarioCommand : IRequest<Guid>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public RegistrarUsuarioCommand(string email, string password) {
            Email = email;
            Password= password;
        }
        private RegistrarUsuarioCommand() { }

}

}

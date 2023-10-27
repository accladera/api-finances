using Application.Dto;
using MediatR;

namespace Application.UseCases.Commands.Usuarios.IniciarSesion
{
    public record IniciarSesionCommand : IRequest<UsuarioDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public IniciarSesionCommand(string email, string password) {
            Email = email;
            Password= password;
        }
        private IniciarSesionCommand() { }

}

}

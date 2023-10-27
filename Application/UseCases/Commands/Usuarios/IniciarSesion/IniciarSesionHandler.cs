using Application.Dto;
using Domain.Factories.Usuarios;
using Domain.Model.Usuarios;
using Domain.Repositories;
using MediatR;
using SharedKernel.Core;

namespace Application.UseCases.Commands.Usuarios.IniciarSesion
{
    internal class IniciarSesionHandler : IRequestHandler<IniciarSesionCommand, UsuarioDto>
    {
        private readonly IUsuarioRepository _usuarioRepository;


        public IniciarSesionHandler(IUsuarioRepository usuarioRepository )
        {
            _usuarioRepository = usuarioRepository;
        }


        public async Task<UsuarioDto> Handle(IniciarSesionCommand request, CancellationToken cancellationToken)
        {
            var usuario = await Validate(request);
            var usuarioRespuesta = new UsuarioDto();
            usuarioRespuesta.Id = usuario.Id;
            usuarioRespuesta.Saldo = usuario.SaldoTotal;
            usuarioRespuesta.Email = usuario.Email;
            return usuarioRespuesta;
        }


        protected async Task<Usuario> Validate(IniciarSesionCommand request)
        {
            var usuario = await _usuarioRepository.FindByEmailAsync(request.Email);
            if(usuario == null )
            {
                throw new InvalidOperationException("Usuario incorrecto.");
            }
            if (!usuario.ValidarCredenciales(request.Email, request.Password))
                {
                    throw new InvalidOperationException("Las credenciales son incorrectas");
                }
             return usuario;
           
        }









    }
}


using Domain.Factories.Usuarios;
using Domain.Repositories;
using MediatR;
using SharedKernel.Core;

namespace Application.UseCases.Commands.Usuarios.RegistrarUsuario
{
    internal class RegistrarUsuarioHandler : IRequestHandler<RegistrarUsuarioCommand, Guid>
    {


        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioFactory _usuarioFactory;
        private readonly IUnitOfWork _unitOfWork;


        public RegistrarUsuarioHandler(IUsuarioRepository usuarioRepository, IUsuarioFactory usuarioFactory, IUnitOfWork unitOfWork
            )
        {
            _usuarioRepository = usuarioRepository;
            _usuarioFactory = usuarioFactory;
            _unitOfWork = unitOfWork;
        }


        public async Task<Guid> Handle(RegistrarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.FindByEmailAsync(request.Email);
            if (usuario!= null)
            {
                throw new InvalidOperationException("El email ya esta registrado, utilice otro.");
            }
            
            usuario = _usuarioFactory.Create(request.Email, request.Password);
            await _usuarioRepository.CreateAsync(usuario);
            Console.WriteLine("Agrego una user" + usuario.Id);
            await _unitOfWork.Commit();
            usuario.IngresarValoresPorDefecto(usuario.Id);
            await _unitOfWork.Commit();
            return usuario.Id;
        }
    }
}

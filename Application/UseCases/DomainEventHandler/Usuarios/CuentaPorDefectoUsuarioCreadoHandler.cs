using Domain.Event;
using Domain.Factories.Cuentas;
using Domain.Repositories;
using MediatR;
using SharedKernel.Core;

namespace Application.UseCases.DomainEventHandler.Usuarios
{
    public class CuentaPorDefectoUsuarioCreadoHandler : INotificationHandler<UsuarioCreado>
    {
        

        private readonly ICuentaRepository _cuentaRepository;
        private readonly ICuentaFactory _cuentaFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CuentaPorDefectoUsuarioCreadoHandler(
            ICuentaRepository cuentaRepository,
            ICuentaFactory cuentaFactory,
            IUnitOfWork unitOfWork)
        {
            _cuentaRepository = cuentaRepository;
            _cuentaFactory = cuentaFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UsuarioCreado notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("Agrego una cuenta", notification.Id);
            var cuentaPorDefecto = _cuentaFactory.Create(notification.UsuarioId, "Efectivo", 1);
            await  _cuentaRepository.CreateAsync(cuentaPorDefecto);
            //await _unitOfWork.Commit();
        }
    }
}

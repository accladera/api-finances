using Domain.Event;
using Domain.Factories.Cuentas;
using Domain.Repositories;
using MediatR;
using SharedKernel.Core;

namespace Application.UseCases.DomainEventHandler.Cuentas
{
    public class CuentaRemovidaHandler : INotificationHandler<CuentaRemovida>
    {
        private readonly ICuentaRepository _cuentaRepository;
        private readonly IMovimientoRepository _movimientoRepository;
        private readonly ICuentaFactory _cuentaFactory;

        private readonly IUnitOfWork _unitOfWork;

        public CuentaRemovidaHandler(
            ICuentaRepository cuentaRepository,
            ICuentaFactory cuentaFactory,
            IMovimientoRepository movimientoRepository,
        IUnitOfWork unitOfWork)
        {
            _cuentaRepository = cuentaRepository;
            _cuentaFactory = cuentaFactory;
            _movimientoRepository = movimientoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CuentaRemovida notification, CancellationToken cancellationToken)
        {
            var cuenta = await _cuentaRepository.FindByIdAsync(notification.CuentaId);
            if (cuenta == null)
            {
                throw new NullReferenceException("La cuenta no exíste.");
            }
            Console.WriteLine("remove all start");
            _movimientoRepository.RemoveAllByCuentaId(notification.CuentaId);
            Console.WriteLine("remove all end");


        }
    }
}

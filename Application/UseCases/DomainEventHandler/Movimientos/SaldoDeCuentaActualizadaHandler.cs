using Domain.Event;
using Domain.Factories.Categorias;
using Domain.Factories.Cuentas;
using Domain.Model.Movimientos;
using Domain.Repositories;
using MediatR;
using SharedKernel.Core;
using System;

namespace Application.UseCases.DomainEventHandler.Movimientos
{


    public class SaldoDeCuentaActualizadaHandler : INotificationHandler<SaldoDeCuentaActualizado>
    {



        private readonly ICuentaRepository _cuentaRepository;
        private readonly ICuentaFactory _cuentaFactory;
        private readonly IUnitOfWork _unitOfWork;


        public SaldoDeCuentaActualizadaHandler(
           ICuentaRepository cuentaRepository,
            ICuentaFactory cuentaFactory,
            IUnitOfWork unitOfWork)
        {

            _cuentaRepository = cuentaRepository;
            _cuentaFactory = cuentaFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(SaldoDeCuentaActualizado notification, CancellationToken cancellationToken)
        {

            var cuenta = await _cuentaRepository.FindByIdAsync(notification.CuentaId);
            if (cuenta == null)
            {
                throw new EntryPointNotFoundException("No existe");

            }
            if( notification.Tipo == TipoMovimiento.Ingreso)
            {
              cuenta.ActualizarSaldo( notification.Monto, TipoMovimiento.Ingreso);
            }
            else
            {
                cuenta.ActualizarSaldo(notification.Monto, TipoMovimiento.Egreso);
            }


            Console.WriteLine("Editar saldo a una cuenta");
            await _cuentaRepository.UpdateAsync(cuenta);
            //await _unitOfWork.Commit();



        }
    }
}

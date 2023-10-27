
using Domain.Factories.Cuentas;
using Domain.Model.Categorias;
using Domain.Repositories;
using MediatR;
using SharedKernel.Core;

namespace Application.UseCases.Commands.Cuentas.ActualizarCuenta
{ 
    public class ActualizarCuentaHandler : IRequestHandler<ActualizarCuentaCommand, Guid>
    {
        private readonly ICuentaRepository _cuentaRepository;
        private readonly ICuentaFactory _cuentaFactory;
        private readonly IUnitOfWork _unitOfWork;


        public ActualizarCuentaHandler(ICuentaRepository cuentaRepository, ICuentaFactory cuentaFactory, IUnitOfWork unitOfWork)
        {
            _cuentaRepository = cuentaRepository;
            _cuentaFactory = cuentaFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(ActualizarCuentaCommand request, CancellationToken cancellationToken)
        {
            var cuenta = await _cuentaRepository.FindByIdAsync(request.Id);
            if (cuenta == null)
            {
                throw new InvalidOperationException("No existe la cuenta.");
            }
            cuenta.EditarCuenta(request.Nombre,request.Saldo);

            await _cuentaRepository.UpdateAsync(cuenta);
            await _unitOfWork.Commit();
            return cuenta.Id;
        }
    }



}

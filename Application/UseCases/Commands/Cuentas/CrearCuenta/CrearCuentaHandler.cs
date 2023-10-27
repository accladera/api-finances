
using Domain.Factories.Cuentas;
using Domain.Repositories;
using MediatR;
using SharedKernel.Core;
using System.Linq.Expressions;

namespace Application.UseCases.Commands.Cuentas.CrearCuenta
{
    public class CrearCuentaHandler : IRequestHandler<CrearCuentaCommand, Guid>
    {
        private readonly ICuentaRepository _cuentaRepository;
        private readonly IUsuarioRepository _userRepository;
        private readonly ICuentaFactory _cuentaFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearCuentaHandler(ICuentaFactory cuentaFactory,ICuentaRepository cuentaRepository, IUnitOfWork unitOfWork,
            IUsuarioRepository _userRepository)
        {
            _cuentaFactory = cuentaFactory;
            _unitOfWork = unitOfWork;
            _cuentaRepository = cuentaRepository;
        }

        public async Task<Guid> Handle(CrearCuentaCommand request, CancellationToken cancellationToken)
        {
            var cuenta = _cuentaFactory.Create(request.PropietarioId, request.Nombre, request.Saldo);
            await _cuentaRepository.CreateAsync(cuenta);
            //var usuario = await _userRepository.FindByIdAsync(request.PropietarioId);
          
            //var saldoTotal = usuario.SaldoTotal;
            //saldoTotal = saldoTotal + cuenta.Saldo;
            //usuario.EditarSaldo( saldoTotal);

            //await _userRepository.UpdateAsync(usuario);
            
            
            await _unitOfWork.Commit();

            return cuenta.Id;
        }
    }
}

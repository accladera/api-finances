

using Domain.Factories.Cuentas;
using Domain.Model.Usuarios;
using Domain.Repositories;
using MediatR;
using SharedKernel.Core;

namespace Application.UseCases.Commands.Cuentas.EliminarCuenta
{

    public class EliminarCuentaHandler : IRequestHandler<EliminarCuentaCommand, bool>
    {
        private readonly ICuentaRepository _cuentaRepository;
        private readonly ICuentaFactory _cuentaFactory;
        private readonly IUnitOfWork _unitOfWork;


        public EliminarCuentaHandler(ICuentaRepository cuentaRepository, ICuentaFactory cuentaFactory, IUnitOfWork unitOfWork)
        {
            _cuentaRepository = cuentaRepository;
            _cuentaFactory = cuentaFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(EliminarCuentaCommand request, CancellationToken cancellationToken)
        {
            var cuenta = await _cuentaRepository.FindByIdAsync(request.Id);
            if (cuenta == null)
            {
                throw new InvalidOperationException("No existe.");
            }
            cuenta.EliminarCuenta();
            await _unitOfWork.Commit();

            await _cuentaRepository.RemoveAsync(cuenta);
            Console.WriteLine("Eliminar "+ request.Id+ " "+ cuenta.Nombre);

            await _unitOfWork.Commit();
            return true;
        }
    }
}

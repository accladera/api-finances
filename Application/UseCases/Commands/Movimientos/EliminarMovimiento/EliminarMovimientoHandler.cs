
using Domain.Repositories;
using MediatR;
using SharedKernel.Core;

namespace Application.UseCases.Commands.Movimientos.EliminarMovimiento
{


    public class EliminarMovimientoHandler : IRequestHandler<EliminarMovimientoCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMovimientoRepository _movimientoRepository;
     

        public EliminarMovimientoHandler( IMovimientoRepository movimientoRepository, IUnitOfWork unitOfWork)
        {
            _movimientoRepository = movimientoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(EliminarMovimientoCommand request, CancellationToken cancellationToken)
        {

            var movimiento = await _movimientoRepository.FindByIdAsync(request.Id);                 
            await _movimientoRepository.RemoveAsync(movimiento);
            movimiento.EliminarMovimiento();
            await _unitOfWork.Commit();
            return true;

        }


    }







}

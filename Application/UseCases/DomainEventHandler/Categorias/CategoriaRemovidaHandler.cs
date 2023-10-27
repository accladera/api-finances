using Application.Dto;
using Domain.Event;
using Domain.Factories.Categorias;
using Domain.Repositories;
using MediatR;
using SharedKernel.Core;

namespace Application.UseCases.DomainEventHandler.Categorias
{
  

    public class CategoriaRemovidaHandler : INotificationHandler<CategoriaRemovida>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMovimientoRepository _movimientoRepository;
        private readonly ICategoriaFactory _categoriaFactory;

        private readonly IUnitOfWork _unitOfWork;

        public CategoriaRemovidaHandler(
            ICategoriaRepository categoriaRepository,
            ICategoriaFactory categoriaFactory,
            IMovimientoRepository movimientoRepository,
        IUnitOfWork unitOfWork)
        {
            _categoriaRepository = categoriaRepository;
            _categoriaFactory = categoriaFactory;
            _movimientoRepository = movimientoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CategoriaRemovida notification, CancellationToken cancellationToken)
        {
            var categoria = await _categoriaRepository.FindByIdAsync(notification.CategoriaId);
            if (categoria == null)
            {
                throw new NullReferenceException("La categorìa no exíste.");
            }
            //var nuevaAsignada=  _categoriaRepository.FindDefault();
            var lista = await _movimientoRepository.GetAllByCategoria(notification.CategoriaId);
            //foreach (var item in lista)
            //{
            //    var movimiento = item;
            //    movimiento.ActualizarMovimiento(movimiento.Fecha,movimiento.Descripcion, 
            //        nuevaAsignada.Id, movimiento.Tipo, movimiento.Monto);
            //    await  _movimientoRepository.UpdateAsync(movimiento);
            //}
        }
    }
}

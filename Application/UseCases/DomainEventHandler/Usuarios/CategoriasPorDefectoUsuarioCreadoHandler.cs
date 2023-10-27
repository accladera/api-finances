using Domain.Event;
using Domain.Factories.Categorias;
using Domain.Model.Categorias;
using Domain.Repositories;
using MediatR;
using SharedKernel.Core;

namespace Application.UseCases.DomainEventHandler.Usuarios
{
  

    public class CategoriasPorDefectoUsuarioCreadoHandler : INotificationHandler<UsuarioCreado>
    {


        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ICategoriaFactory _categoriaFactory;

        private readonly IUnitOfWork _unitOfWork;

        public CategoriasPorDefectoUsuarioCreadoHandler(
             ICategoriaRepository categoriaRepository,
            ICategoriaFactory categoriaFactory,
            IUnitOfWork unitOfWork)
        {
            _categoriaRepository = categoriaRepository;
            _categoriaFactory = categoriaFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UsuarioCreado notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("Agrego una cat", notification.Id);
            var categoriaBase = _categoriaFactory.Create("Otros", notification.UsuarioId);
            var categoriaServicios = _categoriaFactory.Create("Servicios básicos", notification.UsuarioId);
            var categoriaEntretenimiento = _categoriaFactory.Create("Entretenimiento", notification.UsuarioId);
            var categoriaAlimentos = _categoriaFactory.Create("Alimentación", notification.UsuarioId);
            var categoriaTransporte = _categoriaFactory.Create("Transporte", notification.UsuarioId);
                        _categoriaRepository.Add(categoriaBase);
            _categoriaRepository.Add(categoriaServicios);
            _categoriaRepository.Add(categoriaEntretenimiento);
            _categoriaRepository.Add(categoriaAlimentos);
            _categoriaRepository.Add(categoriaTransporte);






        }
    }
}

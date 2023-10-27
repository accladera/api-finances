using Domain.Factories.Categorias;
using Domain.Repositories;
using MediatR;
using SharedKernel.Core;

namespace Application.UseCases.Commands.Categorias.RegistrarCategoria
{
    public class RegistrarCategoriaHandler : IRequestHandler<RegistrarCategoriaCommand, Guid>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ICategoriaFactory _categoriaFactory;
        private readonly IUnitOfWork _unitOfWork;


        public RegistrarCategoriaHandler(ICategoriaRepository categoriaRepository, ICategoriaFactory categoriaFactory,  IUnitOfWork unitOfWork)
        {
            _categoriaRepository = categoriaRepository;
            _categoriaFactory = categoriaFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(RegistrarCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = _categoriaFactory.Create(request.Nombre, request.PropietarioId);
            await _categoriaRepository.CreateAsync(categoria);
            await _unitOfWork.Commit();
            return categoria.Id;
        }
    }
}

using Domain.Factories.Categorias;
using Domain.Repositories;
using MediatR;
using SharedKernel.Core;

namespace Application.UseCases.Commands.Categorias.EliminarCategoria
{
    public class EliminarCategoriaHandler : IRequestHandler<ElimiarCategoriaCommand, bool>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ICategoriaFactory _categoriaFactory;
        private readonly IUnitOfWork _unitOfWork;


        public EliminarCategoriaHandler(ICategoriaRepository categoriaRepository, ICategoriaFactory categoriaFactory, IUnitOfWork unitOfWork)
        {
            _categoriaRepository = categoriaRepository;
            _categoriaFactory = categoriaFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(ElimiarCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = await _categoriaRepository.FindByIdAsync(request.Id);
            if (categoria == null)
            {
                throw new InvalidOperationException("No existe.");
            }
            //categoria.EliminarCategoria();
            await _categoriaRepository.RemoveAsync(categoria);
            await _unitOfWork.Commit();
            return true;
        }
    }
}

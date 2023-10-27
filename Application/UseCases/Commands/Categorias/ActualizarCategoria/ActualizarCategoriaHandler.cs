using Domain.Factories.Categorias;
using Domain.Repositories;
using MediatR;
using SharedKernel.Core;
namespace Application.UseCases.Commands.Categorias.ActualizarCategoria
{
    public class ActualizarCategoriaHandler : IRequestHandler<ActualizarCategoriaCommand, Guid>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ICategoriaFactory _categoriaFactory;
        private readonly IUnitOfWork _unitOfWork;


        public ActualizarCategoriaHandler(ICategoriaRepository categoriaRepository, ICategoriaFactory categoriaFactory, IUnitOfWork unitOfWork)
        {
            _categoriaRepository = categoriaRepository;
            _categoriaFactory = categoriaFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(ActualizarCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = await _categoriaRepository.FindByIdAsync(request.Id);
            if( categoria == null)
            {
                throw new InvalidOperationException("No existe la categoria.");
            }
            categoria.EditarCategoria(request.Nombre);
           await _categoriaRepository.UpdateAsync(categoria);
           await _unitOfWork.Commit();
            return categoria.Id;
        }
    }
}

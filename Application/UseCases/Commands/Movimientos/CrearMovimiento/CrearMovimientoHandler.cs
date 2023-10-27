using Domain.Factories.Movimientos;
using Domain.Repositories;
using MediatR;
using SharedKernel.Core;

namespace Application.UseCases.Commands.Movimientos.CrearMovimiento
{
    public class CrearMovimientoHandler : IRequestHandler<CrearMovimientoCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMovimientoRepository _movimientoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ICuentaRepository _cuentaRepository;
        private readonly IMovimientoFactory _movimientoFactory;
        private readonly ICategoriaRepository _categoriaRepository;


        public CrearMovimientoHandler(IMovimientoFactory movimientoFactory, IMovimientoRepository movimientoRepository
            ,ICuentaRepository cuentaRepository, IUsuarioRepository usuarioRepository, 
           ICategoriaRepository categoriaRepository ,IUnitOfWork unitOfWork)
        {
            _movimientoFactory = movimientoFactory;
            _movimientoRepository= movimientoRepository;
            _cuentaRepository = cuentaRepository;
            _usuarioRepository= usuarioRepository;
            _categoriaRepository = categoriaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CrearMovimientoCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.FindByIdAsync(request.UsuarioId);
            if (usuario == null)
            {
                throw new InvalidOperationException("No existe el propietario.");
            }
            var cuenta = await _cuentaRepository.FindByIdAsync(request.CuentaId);
            if (cuenta == null)
            {
                throw new InvalidOperationException("No existe la cuenta.");
            }
            var categoria = await _categoriaRepository.FindByIdAsync(request.CategoriaId);
            if (categoria == null)
            {
                throw new InvalidOperationException("No existe la categoria.");
            }

                var movimiento = _movimientoFactory.CrearMovimiento( request.Fecha,
                request.Descripcion, request.Tipo, request.UsuarioId, request.CuentaId, request.CategoriaId, 
                request.Monto, cuenta.Saldo);

                await _movimientoRepository.CreateAsync(movimiento);
                await _unitOfWork.Commit();
                return movimiento.Id;
           
        }
      

    }
}

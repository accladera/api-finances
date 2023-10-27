using Domain.Model.Categorias;
using Domain.Model.Cuentas;
using Domain.Model.Movimientos;
using Domain.Repositories;
using Infrastructure.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EF.Repository
{

    internal class MovimientoRepository : IMovimientoRepository
    {

        private readonly WriteDbContext _context;

        public MovimientoRepository(WriteDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Movimiento obj)
        {
            await _context.AddAsync(obj);
        }

        public Task UpdateAsync(Movimiento obj)
        {
            _context.Movimientos.Update(obj);
            return Task.CompletedTask;
        }

        public Task RemoveAsync(Movimiento obj)
        {
            _context.Movimientos.Remove(obj);
            return Task.CompletedTask;
        }

        public async Task<Movimiento?> FindByIdAsync(Guid id)
        {
            return await _context.Movimientos.FirstOrDefaultAsync(c=> c.Id == id);
        }
        public async Task<ICollection<Movimiento>> GetAll()
        {
            return await _context.Movimientos.ToListAsync();
        }

       public async Task  <ICollection<Movimiento>> GetAllByCategoria(Guid categoriaId)
        {
            return await _context.Movimientos.Where(x => x.CategoriaId.Id == categoriaId).ToListAsync();
        }
        public Task  RemoveAllByCuentaId(Guid cuentaId)
        {
            var rango = _context.Movimientos.Where(x => x.CuentaId == new SharedKernel.ValueObjects.GuidVerificadoValue(cuentaId)).ToList();
            _context.Movimientos.RemoveRange(rango);
            return Task.CompletedTask;
        }
    }
}

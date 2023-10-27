using Domain.Model.Cuentas;
using Domain.Repositories;
using Infrastructure.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EF.Repository
{
  
    internal class CuentaRepository : ICuentaRepository
    {
        private readonly WriteDbContext _context;

        public CuentaRepository(WriteDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Cuenta obj)
        {
            await _context.AddAsync(obj);
        }

        public async Task<Cuenta?> FindByIdAsync(Guid id)
        {
            return await _context.Cuentas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task RemoveAsync(Cuenta obj)
        {
            _context.Cuentas.Remove(obj);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Cuenta obj)
        {
            _context.Cuentas.Update(obj);
            return Task.CompletedTask;
        }
    }
}

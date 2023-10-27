using Domain.Model.Usuarios;
using Domain.Repositories;
using Infrastructure.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EF.Repository
{
    internal class UsuarioRepository : IUsuarioRepository
    {
        private readonly WriteDbContext _context;

        public UsuarioRepository(WriteDbContext context)
        {
            _context = context;
        }
       
        public async Task CreateAsync(Usuario obj)
        {
            await _context.AddAsync(obj);
        }

        public async Task<Usuario> FindByEmailAsync(string email)
        {
            return await _context.Usuarios.Where(x => x.Email == email).FirstOrDefaultAsync();
        }

        public async Task<Usuario?> FindByIdAsync(Guid id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x =>x.Id == id);
        }

        public Task RemoveAsync(Usuario obj)
        {
            _context.Usuarios.Remove(obj);
            return Task.CompletedTask;
        }


        public Task UpdateAsync(Usuario obj)
        {
            _context.Usuarios.Update(obj);
            return Task.CompletedTask;
        }
    }
}

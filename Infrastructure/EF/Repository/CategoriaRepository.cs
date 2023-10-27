using Domain.Model.Categorias;
using Domain.Model.Usuarios;
using Domain.Repositories;
using Infrastructure.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EF.Repository
{
    internal class CategoriaRepository : ICategoriaRepository
    {
        private readonly WriteDbContext _context;

        public CategoriaRepository(WriteDbContext context)
        {
            _context = context;
        }
        public Task Add(Categoria obj)
        {
            _context.AddAsync(obj);
            return Task.CompletedTask;
        }

        public async Task CreateAsync(Categoria obj)
        {
            await _context.AddAsync(obj);
        }

        public async Task<Categoria?> FindByIdAsync(Guid id)
        {
            return await _context.Categorias.FirstOrDefaultAsync(x => x.Id == id);
        }
        //public  async Task<Categoria> FindDefault()
        //{
        //    return await _context.Categorias.FirstOrDefaultAsync(x => x.Nombre == "Otros") ;
        //}

        public  Task RemoveAsync(Categoria obj)
        {
            _context.Categorias.Remove(obj);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            return Task.CompletedTask;
        }
    }
}
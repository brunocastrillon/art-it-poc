using CRUD.Core.Domain.Contracts;
using CRUD.Infra.Data.Contexts;

namespace CRUD.Infra.Data.Repository
{
    public class BaseRepository : IBaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
                _context = context;
        }

        public async Task<T> CreateAsync<T>(T entity) where T : class
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync<T>(T entity) where T : class
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync<T>(T entity) where T : class
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
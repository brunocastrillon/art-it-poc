using CRUD.Core.Domain.Contracts;
using CRUD.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

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

        /// 
        /// - alternativa ao AsNoTracking usado no método GetByIdAsync
        /// 
        //public async Task<T> UpdateAsync<T>(T entity) where T : class
        //{
        //    var entry = _context.Entry(entity);

        //    // Se já está sendo rastreado no contexto, precisamos desanexar para evitar conflito
        //    var key = _context.Model.FindEntityType(typeof(T))?.FindPrimaryKey();
        //    if (key != null)
        //    {
        //        var keyValues = key.Properties.Select(p => entry.Property(p.Name).CurrentValue).ToArray();

        //        var local = _context.Set<T>().Local
        //            .FirstOrDefault(e => key.Properties
        //                .Select(p => p.PropertyInfo.GetValue(e))
        //                .SequenceEqual(keyValues));

        //        if (local != null && !ReferenceEquals(local, entity))
        //        {
        //            _context.Entry(local).State = EntityState.Detached;
        //        }
        //    }

        //    _context.Update(entity);
        //    await _context.SaveChangesAsync();
        //    return entity;
        //}
    }
}
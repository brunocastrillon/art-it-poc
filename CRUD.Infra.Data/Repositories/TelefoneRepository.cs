using CRUD.Core.Domain.Contracts;
using CRUD.Core.Domain.Entities;
using CRUD.Infra.Data.Contexts;
using CRUD.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Infra.Data.Repositories
{
    public class TelefoneRepository : BaseRepository, ITelefoneRepository
    {
        public TelefoneRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Telefone>> GetAsync()
        {
            return await _context.Telefones.ToListAsync();
        }

        public async Task<Telefone> GetByIdAsync(int id)
        {
            return await _context.Telefones.FindAsync(id);
        }
    }
}
using CRUD.Core.Domain.Contracts;
using CRUD.Core.Domain.Entities;
using CRUD.Infra.Data.Contexts;
using CRUD.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Infra.Data.Repositories
{
    public class TipoTelefoneRepository : BaseRepository, ITipoTelefoneRepository
    {
        public TipoTelefoneRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<TipoTelefone>> GetAsync()
        {
            return await _context.TiposTelefones.ToListAsync();
        }

        public async Task<TipoTelefone> GetByIdAsync(int id)
        {
            return await _context.TiposTelefones.FindAsync(id);
        }
    }
}
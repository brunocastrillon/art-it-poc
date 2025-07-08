using CRUD.Core.Domain.Contracts;
using CRUD.Core.Domain.Entities;
using CRUD.Infra.Data.Contexts;
using CRUD.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Infra.Data.Repositories
{
    public class ClienteRepository : BaseRepository, IClienteRepository
    {
        public ClienteRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Cliente>> GetAsync()
        {
            return await _context.Clientes.Include(c => c.Telefones)
                                          .ThenInclude(t => t.TipoTelefone)
                                          .ToListAsync();
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            return await _context.Clientes.AsNoTracking()
                                          .Include(c => c.Telefones)
                                          .ThenInclude(t => t.TipoTelefone)
                                          .FirstOrDefaultAsync(c => c.CodigoCliente == id);

        }
    }
}
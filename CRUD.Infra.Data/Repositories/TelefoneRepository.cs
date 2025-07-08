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

        public async Task<bool> DeleteTelefoneAsync(int codigoCliente, string numeroTelefone)
        {
            Telefone? telefone = await _context.Telefones.FirstOrDefaultAsync(t => t.CodigoCliente == codigoCliente &&
                                                                                   t.NumeroTelefone == numeroTelefone);

            if (telefone == null)
                return false;

            _context.Telefones.Remove(telefone);

            await _context.SaveChangesAsync();
            
            return true;
        }

        public async Task<IEnumerable<Telefone>> GetAsync()
        {
            return await _context.Telefones.ToListAsync();
        }

        public async Task<IEnumerable<Telefone>> GetByClienteAsync(int codigoCliente)
        {
            return await _context.Telefones.Where(m => m.CodigoCliente == codigoCliente).ToListAsync();
        }

        public async Task<Telefone?> GetByIdAsync(int codigoCliente, string numeroTelefone)
        {
            return await _context.Telefones.AsNoTracking()
                                           .Include(t => t.TipoTelefone) // opcional
                                           .FirstOrDefaultAsync(t => t.CodigoCliente == codigoCliente &&
                                                                     t.NumeroTelefone == numeroTelefone);
        }
    }
}
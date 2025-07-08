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
            return await _context.Telefones.AsNoTracking()
                                           .Include(t => t.TipoTelefone)
                                           .Where(m => m.CodigoCliente == codigoCliente)
                                           .ToListAsync();
        }

        public async Task<Telefone?> GetByIdAsync(int codigoCliente, string numeroTelefone)
        {
            return await _context.Telefones.AsNoTracking()
                                           .Include(t => t.TipoTelefone)
                                           .FirstOrDefaultAsync(t => t.CodigoCliente == codigoCliente &&
                                                                     t.NumeroTelefone == numeroTelefone);
        }

        public async Task RemoverTelefonesAntigosAsync(int codigoCliente)
        {
            List<Telefone> telefonesAntigos = await _context.Telefones.Where(t => t.CodigoCliente == codigoCliente).ToListAsync();

            if (telefonesAntigos.Any())
            {
                _context.Telefones.RemoveRange(telefonesAntigos);
                await _context.SaveChangesAsync();

                foreach (var telefone in telefonesAntigos)
                {
                    _context.Entry(telefone).State = EntityState.Detached;
                }
            }
        }
    }
}
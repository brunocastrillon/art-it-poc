using CRUD.Core.Domain.Entities;

namespace CRUD.Core.Domain.Contracts
{
    public  interface ITelefoneRepository : IBaseRepository
    {
        Task<IEnumerable<Telefone>> GetAsync();

        Task<Telefone> GetByIdAsync(int id);
    }
}
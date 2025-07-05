using CRUD.Core.Domain.Entities;

namespace CRUD.Core.Domain.Contracts
{
    public  interface ITipoTelefoneRepository : IBaseRepository
    {
        Task<IEnumerable<TipoTelefone>> GetAsync();

        Task<TipoTelefone> GetByIdAsync(int id);
    }
}
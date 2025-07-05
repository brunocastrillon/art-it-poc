using CRUD.Core.Domain.Entities;

namespace CRUD.Core.Domain.Contracts
{
    public  interface IClienteRepository : IBaseRepository
    {
        Task<IEnumerable<Cliente>> GetAsync();

        Task<Cliente> GetByIdAsync(int id);
    }
}
using CRUD.Core.Domain.Entities;

namespace CRUD.Core.Domain.Contracts
{
    public  interface ITelefoneRepository : IBaseRepository
    {
        Task<IEnumerable<Telefone>> GetAsync();

        Task<IEnumerable<Telefone>> GetByClienteAsync(int codigoCliente);

        Task<Telefone?> GetByIdAsync(int codigoCliente, string numeroTelefone);

        Task<bool> DeleteTelefoneAsync(int codigoCliente, string numeroTelefone);
    }
}
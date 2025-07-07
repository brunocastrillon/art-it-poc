using CRUD.Core.Application.DTO;

namespace CRUD.Core.Application.Services.Cliente
{
    public interface IClienteService
    {
        Task<ClienteDTO> AddAsync(ClienteDTO clienteDTO);

        Task<IEnumerable<ClienteDTO>> GetAsync();

        Task<ClienteDTO> GetByIdAsync(int id);

        Task<ClienteDTO> RemoveAsync(int id);

        Task<ClienteDTO> UpdateAsync(ClienteDTO clienteDTO);
    }
}
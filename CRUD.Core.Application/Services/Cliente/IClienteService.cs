using CRUD.Core.Application.DTO;

namespace CRUD.Core.Application.Services.Cliente
{
    public interface IClienteService
    {
        Task<ClienteResponseDTO> AddAsync(ClienteCreateDTO clienteDTO);

        Task<IEnumerable<ClienteResponseDTO>> GetAsync();

        Task<ClienteResponseDTO> GetByIdAsync(int id);

        Task<ClienteResponseDTO> RemoveAsync(int id);

        Task<ClienteResponseDTO> UpdateAsync(ClienteCreateDTO clienteDTO);
    }
}
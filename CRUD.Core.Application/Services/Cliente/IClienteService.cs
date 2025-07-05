using CRUD.Core.Application.DTO;

namespace CRUD.Core.Application.Services.Cliente
{
    public interface IClienteService
    {
        Task<ClienteDTO> Add(ClienteDTO clienteDTO);

        Task<IEnumerable<ClienteDTO>> Get();

        Task<ClienteDTO> GetById(int id);

        Task<ClienteDTO> Remove(int id);

        Task<ClienteDTO> Update(ClienteDTO clienteDTO);
    }
}
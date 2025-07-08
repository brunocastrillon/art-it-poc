using CRUD.Core.Application.DTO;

namespace CRUD.Core.Application.Services.Telefone
{
    public interface ITelefoneService
    {
        Task<TelefoneResponseDTO> AddAsync(TelefoneCreateDTO telefoneCreateDTO);

        Task<IEnumerable<TelefoneResponseDTO>> GetAsync();

        Task<IEnumerable<TelefoneResponseDTO>> GetByClienteAsync(int codigoCliente);

        Task<TelefoneResponseDTO> GetByIdAsync(int codigoCliente, string numeroTelefone);

        Task<bool> RemoveAsync(int codigoCliente, string numeroTelefone);

        Task<TelefoneResponseDTO> UpdateAsync(TelefoneCreateDTO telefoneCreateDTO);
    }
}
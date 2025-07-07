using CRUD.Core.Application.DTO;

namespace CRUD.Core.Application.Services.Telefone
{
    public interface ITelefoneService
    {
        Task<TelefoneDTO> AddAsync(TelefoneCreateDTO telefoneDTO);

        Task<IEnumerable<TelefoneDTO>> GetAsync();

        Task<IEnumerable<TelefoneDTO>> GetByClienteAsync(int codigoCliente);

        Task<TelefoneDTO> GetByIdAsync(int codigoCliente, string numeroTelefone);

        Task<bool> RemoveAsync(int codigoCliente, string numeroTelefone);

        Task<TelefoneDTO> UpdateAsync(TelefoneCreateDTO telefoneDTO);
    }
}
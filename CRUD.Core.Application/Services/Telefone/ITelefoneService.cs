using CRUD.Core.Application.DTO;

namespace CRUD.Core.Application.Services.Telefone
{
    public interface ITelefoneService
    {
        Task<TelefoneDTO> AddAsync(TelefoneDTO telefoneDTO);

        Task<IEnumerable<TelefoneDTO>> GetAsync();

        Task<TelefoneDTO> GetByIdAsync(int id);

        Task<TelefoneDTO> RemoveAsync(int id);

        Task<TelefoneDTO> UpdateAsync(TelefoneDTO telefoneDTO);
    }
}
using CRUD.Core.Application.DTO;

namespace CRUD.Core.Application.Services.TipoTelefone
{
    public interface ITipoTelefoneService
    {
        Task<TipoTelefoneDTO> AddAsync(TipoTelefoneDTO tipoTelefoneDTO);

        Task<IEnumerable<TipoTelefoneDTO>> GetAsync();

        Task<TipoTelefoneDTO> GetByIdAsync(int id);

        Task<TipoTelefoneDTO> RemoveAsync(int id);

        Task<TipoTelefoneDTO> UpdateAsync(TipoTelefoneDTO tipoTelefoneDTO);
    }
}
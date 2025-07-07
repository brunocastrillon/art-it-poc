using AutoMapper;
using CRUD.Core.Application.DTO;
using CRUD.Core.Domain.Contracts;

namespace CRUD.Core.Application.Services.TipoTelefone
{
    public class TipoTelefoneService : ITipoTelefoneService
    {
        private readonly ITipoTelefoneRepository _tipoTelefoneRepository;
        private readonly IMapper _mapper;

        public TipoTelefoneService(ITipoTelefoneRepository tipoTelefoneRepository, IMapper mapper)
        {
            _tipoTelefoneRepository = tipoTelefoneRepository;
            _mapper = mapper;
        }

        public async Task<TipoTelefoneDTO> AddAsync(TipoTelefoneDTO tipoTelefoneDTO)
        {
            Domain.Entities.TipoTelefone entidade = _mapper.Map<Domain.Entities.TipoTelefone>(tipoTelefoneDTO);
            Domain.Entities.TipoTelefone entidadeResult = await _tipoTelefoneRepository.CreateAsync(entidade);

            TipoTelefoneDTO dtoResult = _mapper.Map<TipoTelefoneDTO>(entidadeResult);

            return dtoResult;
        }

        public async Task<IEnumerable<TipoTelefoneDTO>> GetAsync()
        {
            IEnumerable<Domain.Entities.TipoTelefone> entidade = await _tipoTelefoneRepository.GetAsync();
            IEnumerable<TipoTelefoneDTO> dto = _mapper.Map<IEnumerable<TipoTelefoneDTO>>(entidade);
            
            return dto;
        }

        public async Task<TipoTelefoneDTO> GetByIdAsync(int id)
        {
            Domain.Entities.TipoTelefone entidade = await _tipoTelefoneRepository.GetByIdAsync(id);
            TipoTelefoneDTO dto = _mapper.Map<TipoTelefoneDTO>(entidade);
            
            return dto;
        }

        public async Task<TipoTelefoneDTO> RemoveAsync(int id)
        {
            Domain.Entities.TipoTelefone entidade = _tipoTelefoneRepository.GetByIdAsync(id).Result;
            Domain.Entities.TipoTelefone entidadeResult = await _tipoTelefoneRepository.DeleteAsync(entidade);

            TipoTelefoneDTO dtoResult = _mapper.Map<TipoTelefoneDTO>(entidadeResult);
            
            return dtoResult;
        }

        public async Task<TipoTelefoneDTO> UpdateAsync(TipoTelefoneDTO tipoTelefoneDTO)
        {
            Domain.Entities.TipoTelefone entidade = _mapper.Map<Domain.Entities.TipoTelefone>(tipoTelefoneDTO);
            Domain.Entities.TipoTelefone entidadeResult = await _tipoTelefoneRepository.UpdateAsync(entidade);

            TipoTelefoneDTO dtoResult = _mapper.Map<TipoTelefoneDTO>(entidadeResult);
            
            return dtoResult;
        }
    }
}
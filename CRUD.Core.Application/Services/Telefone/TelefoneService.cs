using AutoMapper;
using CRUD.Core.Application.DTO;
using CRUD.Core.Domain.Contracts;

namespace CRUD.Core.Application.Services.Telefone
{
    public class TelefoneService : ITelefoneService
    {
        private readonly ITelefoneRepository _telefoneRepository;
        private readonly IMapper _mapper;

        public TelefoneService(ITelefoneRepository telefoneRepository, IMapper mapper)
        {
            _telefoneRepository = telefoneRepository;
            _mapper = mapper;
        }

        public async Task<TelefoneDTO> AddAsync(TelefoneDTO telefoneDTO)
        {
            Domain.Entities.Telefone entidade = _mapper.Map<Domain.Entities.Telefone>(telefoneDTO);
            Domain.Entities.Telefone entidadeResult = await _telefoneRepository.CreateAsync(entidade);
            
            TelefoneDTO dtoResult = _mapper.Map<TelefoneDTO>(entidadeResult);

            return dtoResult;
        }

        public async Task<IEnumerable<TelefoneDTO>> GetAsync()
        {
            IEnumerable<Domain.Entities.Telefone> entidade = await _telefoneRepository.GetAsync();
            IEnumerable<TelefoneDTO> dto = _mapper.Map<IEnumerable<TelefoneDTO>>(entidade);
            
            return dto;
        }

        public async Task<TelefoneDTO> GetByIdAsync(int id)
        {
            Domain.Entities.Telefone entidade = await _telefoneRepository.GetByIdAsync(id);
            TelefoneDTO dto = _mapper.Map<TelefoneDTO>(entidade);
            
            return dto;
        }

        public async Task<TelefoneDTO> RemoveAsync(int id)
        {
            Domain.Entities.Telefone entidade = _telefoneRepository.GetByIdAsync(id).Result;
            Domain.Entities.Telefone entidadeResult = await _telefoneRepository.DeleteAsync(entidade);
            
            TelefoneDTO dtoResult = _mapper.Map<TelefoneDTO>(entidadeResult);
            
            return dtoResult;
        }

        public async Task<TelefoneDTO> UpdateAsync(TelefoneDTO TelefoneDTO)
        {
            Domain.Entities.Telefone entidade = _mapper.Map<Domain.Entities.Telefone>(TelefoneDTO);
            Domain.Entities.Telefone entidadeResult = await _telefoneRepository.UpdateAsync(entidade);
            
            TelefoneDTO dtoResult = _mapper.Map<TelefoneDTO>(entidadeResult);
            
            return dtoResult;
        }
    }
}
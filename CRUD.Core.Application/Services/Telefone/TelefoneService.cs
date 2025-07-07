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

        public async Task<TelefoneDTO> AddAsync(TelefoneCreateDTO telefoneDTO)
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

        public async Task<IEnumerable<TelefoneDTO>> GetByClienteAsync(int codigoCliente)
        {
            IEnumerable<Domain.Entities.Telefone> entidade = await _telefoneRepository.GetByClienteAsync(codigoCliente);
            IEnumerable<TelefoneDTO> dto = _mapper.Map<IEnumerable<TelefoneDTO>>(entidade);

            return dto;
        }

        public async Task<TelefoneDTO> GetByIdAsync(int codigoCliente, string numeroTelefone)
        {
            Domain.Entities.Telefone entidade = await _telefoneRepository.GetByIdAsync(codigoCliente, numeroTelefone);
            TelefoneDTO dto = _mapper.Map<TelefoneDTO>(entidade);

            return dto;
        }

        public async Task<bool> RemoveAsync(int codigoCliente, string numeroTelefone)
        {
            bool result = await _telefoneRepository.DeleteTelefoneAsync(codigoCliente, numeroTelefone);

            return result;
        }

        public async Task<TelefoneDTO> UpdateAsync(TelefoneCreateDTO TelefoneDTO)
        {
            Domain.Entities.Telefone entidade = _mapper.Map<Domain.Entities.Telefone>(TelefoneDTO);
            Domain.Entities.Telefone entidadeResult = await _telefoneRepository.UpdateAsync(entidade);
            
            TelefoneDTO dtoResult = _mapper.Map<TelefoneDTO>(entidadeResult);
            
            return dtoResult;
        }
    }
}
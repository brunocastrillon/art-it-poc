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

        public async Task<TelefoneResponseDTO> AddAsync(TelefoneCreateDTO telefoneCreateDTO)
        {
            Domain.Entities.Telefone entidade = _mapper.Map<Domain.Entities.Telefone>(telefoneCreateDTO);
            Domain.Entities.Telefone entidadeResult = await _telefoneRepository.CreateAsync(entidade);

            TelefoneResponseDTO dtoResult = _mapper.Map<TelefoneResponseDTO>(entidadeResult);

            return dtoResult;
        }

        public async Task<IEnumerable<TelefoneResponseDTO>> GetAsync()
        {
            IEnumerable<Domain.Entities.Telefone> entidade = await _telefoneRepository.GetAsync();
            IEnumerable<TelefoneResponseDTO> result = _mapper.Map<IEnumerable<TelefoneResponseDTO>>(entidade);
            
            return result;
        }

        public async Task<IEnumerable<TelefoneResponseDTO>> GetByClienteAsync(int codigoCliente)
        {
            IEnumerable<Domain.Entities.Telefone> entidade = await _telefoneRepository.GetByClienteAsync(codigoCliente);
            IEnumerable<TelefoneResponseDTO> response = _mapper.Map<IEnumerable<TelefoneResponseDTO>>(entidade);

            return response;
        }

        public async Task<TelefoneResponseDTO> GetByIdAsync(int codigoCliente, string numeroTelefone)
        {
            Domain.Entities.Telefone entidade = await _telefoneRepository.GetByIdAsync(codigoCliente, numeroTelefone);
            TelefoneResponseDTO dto = _mapper.Map<TelefoneResponseDTO>(entidade);

            return dto;
        }

        public async Task<bool> RemoveAsync(int codigoCliente, string numeroTelefone)
        {
            bool result = await _telefoneRepository.DeleteTelefoneAsync(codigoCliente, numeroTelefone);

            return result;
        }

        public async Task<TelefoneResponseDTO> UpdateAsync(TelefoneCreateDTO TelefoneCreateDTO)
        {
            Domain.Entities.Telefone entidade = _mapper.Map<Domain.Entities.Telefone>(TelefoneCreateDTO);
            Domain.Entities.Telefone entidadeResult = await _telefoneRepository.UpdateAsync(entidade);

            TelefoneResponseDTO dtoResult = _mapper.Map<TelefoneResponseDTO>(entidadeResult);
            
            return dtoResult;
        }
    }
}
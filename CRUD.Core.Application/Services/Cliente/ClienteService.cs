using AutoMapper;
using CRUD.Core.Application.DTO;
using CRUD.Core.Domain.Contracts;

namespace CRUD.Core.Application.Services.Cliente
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<ClienteResponseDTO> AddAsync(ClienteCreateDTO clienteCreateDTO)
        {
            Domain.Entities.Cliente entidade = _mapper.Map<Domain.Entities.Cliente>(clienteCreateDTO);
            Domain.Entities.Cliente entidadeResult = await _clienteRepository.CreateAsync(entidade);

            ClienteResponseDTO dtoResult = _mapper.Map<ClienteResponseDTO>(entidadeResult);

            return dtoResult;
        }

        public async Task<IEnumerable<ClienteResponseDTO>> GetAsync()
        {
            IEnumerable<Domain.Entities.Cliente> entidade = await _clienteRepository.GetAsync();
            IEnumerable<ClienteResponseDTO> dto = _mapper.Map<IEnumerable<ClienteResponseDTO>>(entidade);
            
            return dto;
        }

        public async Task<ClienteResponseDTO> GetByIdAsync(int id)
        {
            Domain.Entities.Cliente entidade = await _clienteRepository.GetByIdAsync(id);
            ClienteResponseDTO dto = _mapper.Map<ClienteResponseDTO>(entidade);
            
            return dto;
        }

        public async Task<ClienteResponseDTO> RemoveAsync(int id)
        {
            Domain.Entities.Cliente entidade = _clienteRepository.GetByIdAsync(id).Result;
            Domain.Entities.Cliente entidadeResult = await _clienteRepository.DeleteAsync(entidade);

            ClienteResponseDTO dtoResult = _mapper.Map<ClienteResponseDTO>(entidadeResult);
            
            return dtoResult;
        }

        public async Task<ClienteResponseDTO> UpdateAsync(ClienteCreateDTO clienteCreateDTO)
        {
            Domain.Entities.Cliente entidade = _mapper.Map<Domain.Entities.Cliente>(clienteCreateDTO);
            Domain.Entities.Cliente entidadeResult = await _clienteRepository.UpdateAsync(entidade);

            ClienteResponseDTO dtoResult = _mapper.Map<ClienteResponseDTO>(entidadeResult);
            
            return dtoResult;
        }
    }
}
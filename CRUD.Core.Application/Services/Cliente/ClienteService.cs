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

        public async Task<ClienteDTO> AddAsync(ClienteDTO clienteDTO)
        {
            Domain.Entities.Cliente entidade = _mapper.Map<Domain.Entities.Cliente>(clienteDTO);
            Domain.Entities.Cliente entidadeResult = await _clienteRepository.CreateAsync(entidade);
            
            ClienteDTO dtoResult = _mapper.Map<ClienteDTO>(entidadeResult);

            return dtoResult;
        }

        public async Task<IEnumerable<ClienteDTO>> GetAsync()
        {
            IEnumerable<Domain.Entities.Cliente> entidade = await _clienteRepository.GetAsync();
            IEnumerable<ClienteDTO> dto = _mapper.Map<IEnumerable<ClienteDTO>>(entidade);
            
            return dto;
        }

        public async Task<ClienteDTO> GetByIdAsync(int id)
        {
            Domain.Entities.Cliente entidade = await _clienteRepository.GetByIdAsync(id);
            ClienteDTO dto = _mapper.Map<ClienteDTO>(entidade);
            
            return dto;
        }

        public async Task<ClienteDTO> RemoveAsync(int id)
        {
            Domain.Entities.Cliente entidade = _clienteRepository.GetByIdAsync(id).Result;
            Domain.Entities.Cliente entidadeResult = await _clienteRepository.DeleteAsync(entidade);
            
            ClienteDTO dtoResult = _mapper.Map<ClienteDTO>(entidadeResult);
            
            return dtoResult;
        }

        public async Task<ClienteDTO> UpdateAsync(ClienteDTO clienteDTO)
        {
            Domain.Entities.Cliente entidade = _mapper.Map<Domain.Entities.Cliente>(clienteDTO);
            Domain.Entities.Cliente entidadeResult = await _clienteRepository.UpdateAsync(entidade);
            
            ClienteDTO dtoResult = _mapper.Map<ClienteDTO>(entidadeResult);
            
            return dtoResult;
        }
    }
}
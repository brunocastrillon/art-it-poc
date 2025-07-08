using AutoMapper;
using CRUD.Core.Application.DTO;
using CRUD.Core.Application.Services.TipoTelefone;
using CRUD.Core.Domain.Contracts;

namespace CRUD.Core.Application.Services.Cliente
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ITipoTelefoneRepository _tipoTelefoneRepository;
        private readonly ITelefoneRepository _telefoneRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, ITipoTelefoneRepository tipoTelefoneRepository, ITelefoneRepository telefoneRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _tipoTelefoneRepository = tipoTelefoneRepository;
            _telefoneRepository = telefoneRepository;
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
            Domain.Entities.Cliente clienteExistente = await _clienteRepository.GetByIdAsync(clienteCreateDTO.CodigoCliente);

            if (clienteExistente == null)
                throw new Exception("Cliente não encontrado.");

            // Atualiza dados básicos do cliente
            _mapper.Map(clienteCreateDTO, clienteExistente);

            if (clienteExistente.Telefones == null)
                clienteExistente.Telefones = new List<Domain.Entities.Telefone>();

            // 1. Remove telefones que estão na lista de "TelefonesRemovidos"
            if (clienteCreateDTO.TelefonesRemovidos != null && clienteCreateDTO.TelefonesRemovidos.Any())
            {
                foreach (var telefoneRemover in clienteCreateDTO.TelefonesRemovidos)
                {
                    var telefone = clienteExistente.Telefones
                        .FirstOrDefault(t => t.NumeroTelefone == telefoneRemover.NumeroTelefone);

                    if (telefone != null)
                        clienteExistente.Telefones.Remove(telefone);
                }
            }

            // 2. Adiciona novos telefones da lista "Telefones"
            if (clienteCreateDTO.Telefones != null && clienteCreateDTO.Telefones.Any())
            {
                foreach (var telefoneDTO in clienteCreateDTO.Telefones)
                {
                    bool jaExiste = clienteExistente.Telefones
                        .Any(t => t.NumeroTelefone == telefoneDTO.NumeroTelefone);

                    if (jaExiste) continue;

                    var entidade = _mapper.Map<Domain.Entities.Telefone>(telefoneDTO);
                    entidade.CodigoCliente = clienteExistente.CodigoCliente;
                    entidade.Cliente = clienteExistente;
                    entidade.TipoTelefone = await _tipoTelefoneRepository.GetByIdAsync(telefoneDTO.CodigoTipoTelefone);

                    clienteExistente.Telefones.Add(entidade);
                }
            }

            // Salva alterações
            var clienteAtualizado = await _clienteRepository.UpdateAsync(clienteExistente);
            return _mapper.Map<ClienteResponseDTO>(clienteAtualizado);

            //// Remove telefones antigos do contexto e da entidade
            //await _telefoneRepository.RemoverTelefonesAntigosAsync(clienteExistente.CodigoCliente);

            //clienteExistente.Telefones = new List<Domain.Entities.Telefone>();

            //// Mapeia e adiciona os telefones novos
            //List<TelefoneCreateDTO> telefonesNovos = _mapper.Map<List<TelefoneCreateDTO>>(clienteCreateDTO.Telefones);
            //foreach (var telefone in telefonesNovos)
            //{
            //    Domain.Entities.Telefone entidade = _mapper.Map<Domain.Entities.Telefone>(telefone);
            //    entidade.CodigoCliente = clienteCreateDTO.CodigoCliente;
            //    clienteExistente.Telefones.Add(entidade);
            //}

            //// Salva alterações
            //var clienteAtualizado = await _clienteRepository.UpdateAsync(clienteExistente);
            //return _mapper.Map<ClienteResponseDTO>(clienteAtualizado);
        }
    }
}
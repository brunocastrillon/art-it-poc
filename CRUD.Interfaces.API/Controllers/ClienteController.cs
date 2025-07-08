using CRUD.Core.Application.Services.Cliente;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Interfaces.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
                _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Core.Application.DTO.ClienteDTO>>> Get()
        {
            IEnumerable<Core.Application.DTO.ClienteDTO> clientes = await _clienteService.GetAsync();
            
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Core.Application.DTO.ClienteDTO>> Get(int id)
        {
            Core.Application.DTO.ClienteDTO cliente = await _clienteService.GetByIdAsync(id);

            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Core.Application.DTO.ClienteCreateDTO cliente)
        {
            Core.Application.DTO.ClienteResponseDTO result = await _clienteService.AddAsync(cliente);

            
            return CreatedAtAction(nameof(Get), new { id = result.CodigoCliente }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Core.Application.DTO.ClienteCreateDTO cliente)
        {
            if (id != cliente.CodigoCliente)
                return BadRequest("ID do cliente não confere com o corpo da requisição.");

            Core.Application.DTO.ClienteDTO existente = await _clienteService.GetByIdAsync(id);
            
            if (existente == null)
                return NotFound();

            await _clienteService.UpdateAsync(cliente);
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Core.Application.DTO.ClienteDTO cliente = await _clienteService.GetByIdAsync(id);
            
            if (cliente == null)
                return NotFound();

            await _clienteService.RemoveAsync(id);
            
            return NoContent();
        }
    }
}
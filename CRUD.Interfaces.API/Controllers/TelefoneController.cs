using CRUD.Core.Application.Services.Cliente;
using CRUD.Core.Application.Services.Telefone;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Interfaces.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefoneController : ControllerBase
    {
        private readonly ITelefoneService _telefoneService;

        public TelefoneController(ITelefoneService telefoneService)
        {
            _telefoneService = telefoneService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Core.Application.DTO.TelefoneDTO>>> Get()
        {
            IEnumerable<Core.Application.DTO.TelefoneDTO> dto = await _telefoneService.GetAsync();
            
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Core.Application.DTO.TelefoneDTO>> Get(int id)
        {
            Core.Application.DTO.TelefoneDTO dto = await _telefoneService.GetByIdAsync(id);

            if (dto == null)
                return NotFound();

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Core.Application.DTO.TelefoneDTO dto)
        {
            await _telefoneService.AddAsync(dto);

            return CreatedAtAction(nameof(Get), new { id = dto.NumeroTelefone }, dto);
        }

        [HttpPut("{numeroTelefone}")]
        public async Task<ActionResult> Put(int numeroTelefone, [FromBody] Core.Application.DTO.TelefoneDTO dto)
        {
            if (numeroTelefone != int.Parse(dto.NumeroTelefone))
                return BadRequest("ID do tipo de telefone não confere com o corpo da requisição.");

            Core.Application.DTO.TelefoneDTO existente = await _telefoneService.GetByIdAsync(numeroTelefone);
            
            if (existente == null)
                return NotFound();

            await _telefoneService.UpdateAsync(dto);
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Core.Application.DTO.TelefoneDTO dto = await _telefoneService.GetByIdAsync(id);
            
            if (dto == null)
                return NotFound();

            await _telefoneService.RemoveAsync(id);
            
            return NoContent();
        }
    }
}
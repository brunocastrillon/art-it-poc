using CRUD.Core.Application.Services.Cliente;
using CRUD.Core.Application.Services.TipoTelefone;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Interfaces.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoTelefoneController : ControllerBase
    {
        private readonly ITipoTelefoneService _tipoTelefoneService;

        public TipoTelefoneController(ITipoTelefoneService tipoTelefoneService)
        {
            _tipoTelefoneService = tipoTelefoneService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Core.Application.DTO.TipoTelefoneDTO>>> Get()
        {
            IEnumerable<Core.Application.DTO.TipoTelefoneDTO> dto = await _tipoTelefoneService.GetAsync();
            
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Core.Application.DTO.TipoTelefoneDTO>> Get(int id)
        {
            Core.Application.DTO.TipoTelefoneDTO dto = await _tipoTelefoneService.GetByIdAsync(id);

            if (dto == null)
                return NotFound();

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Core.Application.DTO.TipoTelefoneDTO dto)
        {
            Core.Application.DTO.TipoTelefoneDTO result = await _tipoTelefoneService.AddAsync(dto);

            return CreatedAtAction(nameof(Get), new { id = result.CodigoTipoTelefone }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Core.Application.DTO.TipoTelefoneDTO dto)
        {
            if (id != dto.CodigoTipoTelefone)
                return BadRequest("ID do tipo de telefone não confere com o corpo da requisição.");

            Core.Application.DTO.TipoTelefoneDTO existente = await _tipoTelefoneService.GetByIdAsync(id);
            
            if (existente == null)
                return NotFound();

            await _tipoTelefoneService.UpdateAsync(dto);
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Core.Application.DTO.TipoTelefoneDTO dto = await _tipoTelefoneService.GetByIdAsync(id);
            
            if (dto == null)
                return NotFound();

            await _tipoTelefoneService.RemoveAsync(id);
            
            return NoContent();
        }
    }
}
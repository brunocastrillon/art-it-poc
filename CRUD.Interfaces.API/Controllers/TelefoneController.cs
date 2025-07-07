using CRUD.Core.Application.DTO;
using CRUD.Core.Application.Services.Telefone;
using CRUD.Core.Domain.Contracts;
using CRUD.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Interfaces.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TelefonesController : ControllerBase
    {
        private readonly ITelefoneService _telefoneService;

        public TelefonesController(ITelefoneService telefoneService)
        {
            _telefoneService = telefoneService;
        }

        // GET: api/telefones/123
        [HttpGet("{codigoCliente}")]
        public async Task<ActionResult<IEnumerable<TelefoneDTO>>> GetByCliente(int codigoCliente)
        {
            IEnumerable<TelefoneDTO> telefones = await _telefoneService.GetByClienteAsync(codigoCliente);
            
            return Ok(telefones);
        }

        /// <summary>
        /// GET: api/telefones/123/11999998888
        /// </summary>
        /// <param name="codigoCliente"></param>
        /// <param name="numeroTelefone"></param>
        /// <returns></returns>
        [HttpGet("{codigoCliente}/{numeroTelefone}")]
        public async Task<ActionResult<TelefoneDTO>> GetPorId(int codigoCliente, string numeroTelefone)
        {
            var telefone = await _telefoneService.GetByIdAsync(codigoCliente, numeroTelefone);
            if (telefone == null)
                return NotFound();

            return Ok(telefone);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TelefoneCreateDTO telefone)
        {
            await _telefoneService.AddAsync(telefone);
            return CreatedAtAction(nameof(GetPorId), new
            {
                codigoCliente = telefone.CodigoCliente,
                numeroTelefone = telefone.NumeroTelefone
            }, telefone);
        }

        /// <summary>
        /// PUT: api/telefones/123/11999998888
        /// </summary>
        /// <param name="codigoCliente"></param>
        /// <param name="numeroTelefone"></param>
        /// <param name="telefone"></param>
        /// <returns></returns>
        [HttpPut("{codigoCliente}/{numeroTelefone}")]
        public async Task<ActionResult> Put(int codigoCliente, string numeroTelefone, [FromBody] TelefoneCreateDTO telefone)
        {
            if (codigoCliente != telefone.CodigoCliente || numeroTelefone != telefone.NumeroTelefone)
                return BadRequest("Chave primária não confere.");

            var existente = await _telefoneService.GetByIdAsync(codigoCliente, numeroTelefone);
            if (existente == null)
                return NotFound();

            await _telefoneService.UpdateAsync(telefone);
            return NoContent();
        }

        /// <summary>
        /// DELETE: api/telefones/123/11999998888 
        /// </summary>
        /// <param name="codigoCliente"></param>
        /// <param name="numeroTelefone"></param>
        /// <returns></returns>
        [HttpDelete("{codigoCliente}/{numeroTelefone}")]
        public async Task<ActionResult> Delete(int codigoCliente, string numeroTelefone)
        {
            var sucesso = await _telefoneService.RemoveAsync(codigoCliente, numeroTelefone);
            if (!sucesso)
                return NotFound();

            return NoContent();
        }
    }
}
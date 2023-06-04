using Core.Entities;
using Core.Services;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;



namespace API_GAMA.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var enderecoList = await _enderecoService.GetEnderecosAsync();
                return Ok(enderecoList);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao listar os dados");
            }
        }

        // GET api/<EnderecoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var endereco = await _enderecoService.GetEnderecoByIdAsync(id);
                return Ok(endereco);
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }

        // POST api/<EnderecoController>
        [HttpPost]
        public async Task<IActionResult> Post( Endereco endereco)
        {
            try
            {
                await _enderecoService.SaveEnderecoAsync(endereco);
                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }
        }

        // PUT api/<EnderecoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,  Endereco endereco)
        {
            try
            {
                endereco.Id = id;
                await _enderecoService.SaveEnderecoAsync(endereco);
                return Ok();
            }
            catch(Exception ex) 
            {
                return Conflict(ex);
            }
        }

        // DELETE api/<EnderecoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var endereco = await _enderecoService.GetEnderecoByIdAsync(id);
                await _enderecoService.DeleteEnderecoAsync(endereco);
                return Ok();
            }catch(Exception ex) { return BadRequest(); }
        }
    }
}

using Core.Entities;
using Core.Services;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;



namespace API_GAMA.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReclamacaoController : ControllerBase
    {
        private readonly IReclamacaoService _reclamacaoService;

        public ReclamacaoController(IReclamacaoService reclamacaoService)
        {
            _reclamacaoService = reclamacaoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var reclamacaoList = await _reclamacaoService.GetReclamacaosAsync();
                return Ok(reclamacaoList);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao listar os dados");
            }
        }

        // GET api/<ReclamacaoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var reclamacao = await _reclamacaoService.GetReclamacaoByIdAsync(id);
                return Ok(reclamacao);
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }

        // POST api/<ReclamacaoController>
        [HttpPost]
        public async Task<IActionResult> Post(Reclamacao reclamacao)
        {
            try
            {
                await _reclamacaoService.SaveReclamacaoAsync(reclamacao);
                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }
        }

        // PUT api/<ReclamacaoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,  Reclamacao reclamacao)
        {
            try
            {
                //reclamacao.Id = id;
                await _reclamacaoService.SaveReclamacaoAsync(reclamacao);
                return Ok();
            }
            catch(Exception ex) 
            {
                return Conflict(ex);
            }
        }

        // DELETE api/<ReclamacaoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var reclamacao = await _reclamacaoService.GetReclamacaoByIdAsync(id);
                await _reclamacaoService.DeleteReclamacaoAsync(reclamacao);
                return Ok();
            }catch(Exception ex) { return BadRequest(); }
        }
    }
}

using Core.Entities;
using Core.Services;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;



namespace API_GAMA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadaoController : ControllerBase
    {
        private readonly ICidadaoService _cidadaoService;

        public CidadaoController(ICidadaoService cidadaoService)
        {
            _cidadaoService = cidadaoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var cidadaoList = await _cidadaoService.GetAllCidadao();
                return Ok(cidadaoList);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao listar os dados");
            }
        }

        // GET api/<CidadaoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var cidadao = await _cidadaoService.GetCidadaoById(id);
                return Ok(cidadao);
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }

        // POST api/<CidadaoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cidadao cidadao)
        {
            try
            {
                await _cidadaoService.SaveCidadaoAsync(cidadao);
                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }
        }

        // PUT api/<CidadaoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Cidadao cidadao)
        {
            try
            {
                cidadao.Id = id;
                await _cidadaoService.SaveCidadaoAsync(cidadao);
                return Ok();
            }
            catch(Exception ex) 
            {
                return Conflict(ex);
            }
        }

        // DELETE api/<CidadaoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var cidadao = await _cidadaoService.GetCidadaoById(id);
                await _cidadaoService.DeleteCidadaoAsync(cidadao);
                return Ok();
            }catch(Exception ex) { return BadRequest(); }
        }
    }
}

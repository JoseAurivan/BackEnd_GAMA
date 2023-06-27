using Core.Entities;
using Core.Services;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;



namespace API_GAMA.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ChamadoController : ControllerBase
    {
        private readonly IChamadoService _chamadoService;

        public ChamadoController(IChamadoService chamadoService)
        {
            _chamadoService = chamadoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var chamadoList = await _chamadoService.GetChamadosAsync();
                return Ok(chamadoList);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao listar os dados");
            }
        }

        // GET api/<ChamadoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var chamado = await _chamadoService.GetChamadoByIdAsync(id);
                return Ok(chamado);
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }

        // POST api/<ChamadoController>
        [HttpPost]
        public async Task<IActionResult> Post( Chamado chamado)
        {
            try
            {
                await _chamadoService.SaveChamadoAsync(chamado);
                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }
        }

        // PUT api/<ChamadoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,  Chamado chamado)
        {
            try
            {
                //chamado.Id = id;
                await _chamadoService.SaveChamadoAsync(chamado);
                return Ok();
            }
            catch(Exception ex) 
            {
                return Conflict(ex);
            }
        }

        // DELETE api/<ChamadoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var chamado = await _chamadoService.GetChamadoByIdAsync(id);
                await _chamadoService.DeleteChamadoAsync(chamado);
                return Ok();
            }catch(Exception ex) { return BadRequest(); }
        }
    }
}

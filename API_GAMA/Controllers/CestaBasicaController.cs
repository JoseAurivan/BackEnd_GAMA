using Core.Entities;
using Core.Services;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;



namespace API_GAMA.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CestaBasicaController : ControllerBase
    {
        private readonly ICestaBasicaService _cestaService;

        public CestaBasicaController(ICestaBasicaService cestaService)
        {
            _cestaService = cestaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var cestaList = await _cestaService.GetCestaBasicasAsync();
                return Ok(cestaList);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao listar os dados");
            }
        }

        // GET api/<CestaBasicaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var cesta = await _cestaService.getCestaBasicaByIdAsync(id);
                return Ok(cesta);
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }

        // POST api/<CestaBasicaController>
        [HttpPost]
        public async Task<IActionResult> Post( CestaBasica cesta)
        {
            try
            {
                await _cestaService.SaveCestaBasicaAsync(cesta);
                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }
        }

        // PUT api/<CestaBasicaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,  CestaBasica cesta)
        {
            try
            {
                cesta.Id = id;
                await _cestaService.SaveCestaBasicaAsync(cesta);
                return Ok();
            }
            catch(Exception ex) 
            {
                return Conflict(ex);
            }
        }

        // DELETE api/<CestaBasicaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var cesta = await _cestaService.getCestaBasicaByIdAsync(id);
                await _cestaService.DeleteCestaBasicaAsync(cesta);
                return Ok();
            }catch(Exception ex) { return BadRequest(); }
        }
    }
}

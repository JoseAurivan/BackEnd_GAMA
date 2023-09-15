using Core.Entities;
using Core.Services;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;



namespace API_GAMA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamiliaController : ControllerBase
    {
        private readonly IFamiliaService _familiaService;

        public FamiliaController(IFamiliaService familiaService)
        {
            _familiaService = familiaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var familiaList = await _familiaService.GetFamiliaAsync();
                return Ok(familiaList);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao listar os dados");
            }
        }

        // GET api/<FamiliaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var familia = await _familiaService.GetFamiliaByIdAsync(id);
                return Ok(familia);
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }

        // POST api/<FamiliaController>
        [HttpPost]
        public async Task<IActionResult> Post( Familia familia)
        {
            try
            {
                await _familiaService.SaveFamiliaAsync(familia);
                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }
        }

        // PUT api/<FamiliaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,  Familia familia)
        {
            try
            {
                //familia.Id = id;
                await _familiaService.SaveFamiliaAsync(familia);
                return Ok();
            }
            catch(Exception ex) 
            {
                return Conflict(ex);
            }
        }

        // DELETE api/<FamiliaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var familia = await _familiaService.GetFamiliaByIdAsync(id);
                await _familiaService.DeleteFamiliaAsync(familia);
                return Ok();
            }catch(Exception ex) { return BadRequest(); }
        }
    }
}

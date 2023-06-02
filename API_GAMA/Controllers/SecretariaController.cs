using Core.Entities;
using Core.Services;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;



namespace API_GAMA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecretariaController : ControllerBase
    {
        private readonly ISecretariaService _secretariaService;

        public SecretariaController(ISecretariaService secretariaService)
        {
            _secretariaService = secretariaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var secretariaList = await _secretariaService.GetSecretariaAsync();
                return Ok(secretariaList);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao listar os dados");
            }
        }

        // GET api/<SecretariaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var secretaria = await _secretariaService.GetSecretariaByIdAsync(id);
                return Ok(secretaria);
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }

        // POST api/<SecretariaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Secretaria secretaria)
        {
            try
            {
                await _secretariaService.SaveScretariaAsync(secretaria);
                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }
        }

        // PUT api/<SecretariaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Secretaria secretaria)
        {
            try
            {
                secretaria.Id = id;
                await _secretariaService.SaveScretariaAsync(secretaria);
                return Ok();
            }
            catch(Exception ex) 
            {
                return Conflict(ex);
            }
        }

        // DELETE api/<SecretariaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var secretaria = await _secretariaService.GetSecretariaByIdAsync(id);
                await _secretariaService.DeleteSecretariaAsync(secretaria);
                return Ok();
            }catch(Exception ex) { return BadRequest(); }
        }
    }
}

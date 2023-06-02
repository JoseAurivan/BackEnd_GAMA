using Core.Entities;
using Core.Services;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;



namespace API_GAMA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServidorController : ControllerBase
    {
        private readonly IServidorService _servidorService;

        public ServidorController(IServidorService servidorService)
        {
            _servidorService = servidorService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var servidorList = await _servidorService.GetServidors();
                return Ok(servidorList);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao listar os dados");
            }
        }

        // GET api/<ServidorController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var servidor = await _servidorService.GetServidorById(id);
                return Ok(servidor);
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }

        // POST api/<ServidorController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Servidor servidor)
        {
            try
            {
                await _servidorService.SaveServidorAsync(servidor);
                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }
        }

        // PUT api/<ServidorController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Servidor servidor)
        {
            try
            {
                servidor.Id = id;
                await _servidorService.SaveServidorAsync(servidor);
                return Ok();
            }
            catch(Exception ex) 
            {
                return Conflict(ex);
            }
        }

        // DELETE api/<ServidorController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var servidor = await _servidorService.GetServidorById(id);
                await _servidorService.DeleteServidorAsync(servidor);
                return Ok();
            }catch(Exception ex) { return BadRequest(); }
        }
    }
}

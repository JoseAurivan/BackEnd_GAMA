using Core.Entities;
using Core.Services;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SuporteFront;

namespace API_GAMA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServidorController : ControllerBase
    {
        private readonly IServidorService _servidorService;
        private readonly ISecretariaService _secretariaService;
        private readonly ICargoService _cargoService;

        public ServidorController(IServidorService servidorService, ISecretariaService secretariaService, ICargoService cargoService)
        {
            _servidorService = servidorService;
            _secretariaService = secretariaService;
            _cargoService = cargoService;
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

        [HttpGet("matricula/{matricula}")]
        public async Task<IActionResult> GetServidorByMatricula(string matricula)
        {
            try
            {
                
                var servidor = await _servidorService.GetServidorByMatriucla(matricula);
                return Ok(servidor.Secretaria);
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }

        // POST api/<ServidorController>
        [HttpPost]
        public async Task<IActionResult> Post(ServidorViewModel servidorVM)
        {
            try
            {
                var cargo = await _cargoService.GetCargoByIdAsync(servidorVM.CargoId);
                var secretaria = await _secretariaService.GetSecretariaByIdAsync(servidorVM.SecretariaId);
                Servidor servidor = new Servidor(servidorVM.Nome, servidorVM.CPF, servidorVM.Matricula, servidorVM.Senha, servidorVM.Telefone,servidorVM.Email, secretaria, cargo);
                await _servidorService.SaveServidorAsync(servidor);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/<ServidorController>/5
        [HttpPut]
        public async Task<IActionResult> Put(Servidor servidor)
        {
            try
            {
                //servidor.Id = id;
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

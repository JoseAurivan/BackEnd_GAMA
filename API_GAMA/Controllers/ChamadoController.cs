using Core.Entities;
using Core.Entities.Abstract;
using Core.Services;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SuporteFront;

namespace API_GAMA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChamadoController : ControllerBase
    {
        private readonly IChamadoService _chamadoService;
        private readonly ISecretariaService _secretariaService;
        private readonly IServidorService _servidorService;

        public ChamadoController(IChamadoService chamadoService, ISecretariaService secretariaService, IServidorService servidorService)
        {
            _chamadoService = chamadoService;
            _secretariaService = secretariaService;
            _servidorService = servidorService;
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
        [HttpGet("secretaria/{id}")]
        public async Task<IActionResult> GetChamadoFromSecretaria(int id)
        {
            try
            {
                var chamadoList = await _chamadoService.GetChamadosFromSecretaria(id);
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
        public async Task<IActionResult> Post(ChamadoViewModel chamadoVM)
        {
            try
            {
                Secretaria secretaria = await _secretariaService.GetSecretariaByIdAsync(chamadoVM.SecretariaId);
                Servidor solicitadoPor = await _servidorService.GetServidorByMatriucla(chamadoVM.Matricula); 
                Chamado chamado = new Chamado(chamadoVM.Atendimento,chamadoVM.Telefone,chamadoVM.Solicitacao,secretaria,new Guid().ToString(),chamadoVM.Descricao,solicitadoPor,chamadoVM.DataAbertura);
                await _chamadoService.SaveChamadoAsync(chamado);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
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

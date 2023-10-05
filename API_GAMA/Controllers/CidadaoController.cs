using Core.Entities;
using Core.Services;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SuporteFront;
using System.Text.Json;

namespace API_GAMA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadaoController : ControllerBase
    {
        private readonly ICidadaoService _cidadaoService;
        private readonly IEnderecoService _enderecoService;

        public CidadaoController(ICidadaoService cidadaoService, IEnderecoService enderecoService)
        {
            _cidadaoService = cidadaoService;
            _enderecoService = enderecoService;
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
        [HttpPost]
        public async Task<IActionResult> Post(CidadaoEnderecoViewModel cidadaoEndereco)
        {


            try
            {
                var id = await _enderecoService.SaveEnderecoAsync(cidadaoEndereco.Endereco);
                cidadaoEndereco.Cidadao.Endereco = new Endereco();
                cidadaoEndereco.Cidadao.Endereco.Id = id;
                await _cidadaoService.SaveCidadaoAsync(cidadaoEndereco.Cidadao);
                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }
        }

        // PUT api/<CidadaoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Cidadao cidadao)
        {
            try
            {
                return Ok(await _cidadaoService.SaveCidadaoAsync(cidadao));
            }
            catch (Exception ex)
            {
                return BadRequest(0);
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
            }
            catch (Exception ex) { return BadRequest(); }
        }
    }
}

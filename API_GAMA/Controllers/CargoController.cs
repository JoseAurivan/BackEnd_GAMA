using Core.Entities;
using Core.Services;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;



namespace API_GAMA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly ICargoService _cargoService;

        public CargoController(ICargoService cargoService)
        {
            _cargoService = cargoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var cargoList = await _cargoService.GetAllCargosAsync();
                return Ok(cargoList);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao listar os dados");
            }
        }

        // GET api/<CargoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var cargo = await _cargoService.GetCargoByIdAsync(id);
                return Ok(cargo);
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }

        // POST api/<CargoController>
        [HttpPost]
        public async Task<IActionResult> Post(Cargo cargo)
        {
            try
            {
                await _cargoService.SaveCargoAsync(cargo);
                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }
        }

        // PUT api/<CargoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,  Cargo cargo)
        {
            try
            {
                //cargo.Id = id;
                await _cargoService.SaveCargoAsync(cargo);
                return Ok();
            }
            catch(Exception ex) 
            {
                return Conflict(ex);
            }
        }

        // DELETE api/<CargoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var cargo = await _cargoService.GetCargoByIdAsync(id);
                await _cargoService.DeleteCargoAsync(cargo);
                return Ok();
            }catch(Exception ex) { return BadRequest(); }
        }
    }
}

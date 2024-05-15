using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaHutAPI.Models.DB_Models;
using PizzaHutAPI.Models.DTO_Models;
using PizzaHutAPI.Services.Interfaces;

namespace PizzaHutAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Pizza>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Pizza>>> GetPizzas()
        {
            try
            {
                var result = await _pizzaService.GetAllPizzas();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(400, ex.Message));
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Pizza), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pizza>> GetPizza(int id)
        {
            try
            {
                var result = await _pizzaService.GetPizzaById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Pizza), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pizza>> AddPizza(PizzaDTO pizzaDTO)
        {
            try
            {

                var result = await _pizzaService.AddPizza(pizzaDTO);
                return CreatedAtAction(nameof(GetPizza), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(400, ex.Message));
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Pizza), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pizza>> UpdatePizza(int id, PizzaDTO pizzaDTO)
        {
            try
            {
                var result = await _pizzaService.UpdatePizza(id, pizzaDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(400, ex.Message));
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Pizza), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pizza>> DeletePizza(int id)
        {
            try
            {
                var result = await _pizzaService.DeletePizza(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(new ErrorModel(404, e.Message));
            }
        }
    }
}

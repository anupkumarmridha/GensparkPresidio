using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaHutAPI.Models.DB_Models;
using PizzaHutAPI.Models.DTO_Models;
using PizzaHutAPI.Services.Interfaces;

namespace PizzaHutAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Stock>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Stock>>> GetStocks()
        {
            try
            {
                var result = await _stockService.GetAllStocks();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(400, ex.Message));
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Stock), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Stock>> GetStock(int id)
        {
            try
            {
                var result = await _stockService.GetStockById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }

        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(Stock), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Stock>> AddStock(StockDTO stockDTO)
        {
            try
            {
                var result = await _stockService.AddStock(stockDTO);
                return CreatedAtAction(nameof(GetStock), new { id = result.PizzaId }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(400, ex.Message));
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Stock), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Stock>> UpdateStock(int id, StockDTO stockDTO)
        {
            try
            {
                var result = await _stockService.UpdateStock(id, stockDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(400, ex.Message));
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Stock), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Stock>> DeleteStock(int id)
        {
            try
            {
                var result = await _stockService.DeleteStock(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(400, ex.Message));
            }
        }
    }
}

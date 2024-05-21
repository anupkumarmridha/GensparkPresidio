using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApparelShoppingAppAPI.Models.DB_Models;
using ApparelShoppingAppAPI.Models.DTO_Models;
using ApparelShoppingAppAPI.Services.Interfaces;

namespace ApparelShoppingAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        [ProducesResponseType(typeof(IList<Product>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<Product>>> GetProducts()
        {
            try
            {
                var result = await _productService.GetAllProducts();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(400, ex.Message));
            }
        }


        [HttpGet("{idOrName}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetProduct(string idOrName)
        {
            try
            {
                Product result;
                if (int.TryParse(idOrName, out int id))
                {
                    result = await _productService.GetProductById(id);
                }
                else
                {
                    result = await _productService.GetProductByName(idOrName);
                }

                if (result == null)
                {
                    return NotFound(new ErrorModel(404, "Product not found."));
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }

        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Product>> AddProduct(ProductDTO productDTO)
        {
            try
            {

                var result = await _productService.AddProduct(productDTO);
                return CreatedAtAction(nameof(GetProduct), new { id = result.ProductId }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(400, ex.Message));
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Product>> UpdateProduct(int id, ProductDTO productDTO)
        {
            try
            {
                var result = await _productService.UpdateProduct(id, productDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(400, ex.Message));
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            try
            {
                var result = await _productService.DeleteProduct(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(new ErrorModel(404, e.Message));
            }
        }
    }
}

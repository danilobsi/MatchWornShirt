using Microsoft.AspNetCore.Mvc;
using Webshop.API.Services;

namespace Webshop.API.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ProductService _productService;

        public ProductController(ILogger<ProductController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        /// <summary>
        /// Gets a paged list of all products.
        /// </summary>
        /// <param name="page">Page.</param>
        /// <param name="pageSize">Page size.</param>
        /// <returns>Paged list of all products.</returns>
        [HttpGet("Product", Name = "GetAllProducts")]
        public async Task<IActionResult> GetAll([FromQuery] int page = 0, [FromQuery] int pageSize = 10)
        {
            var result = await _productService.GetAll(page, pageSize);
            if (!string.IsNullOrEmpty(result.ErrorMessage))
            {
                if (result.Count == 0)
                {
                    return NotFound(result.ErrorMessage);
                }

                return BadRequest(result.ErrorMessage);
            }

            return Ok(result);
        }

        /// <summary>
        /// Gets a specific product by Id.
        /// </summary>
        /// <param name="id">Product's Id.</param>
        /// <returns>Requested Product.</returns>
        [HttpGet("Product/{id}", Name = "GetProduct")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _productService.Get(id);
            if (!string.IsNullOrEmpty(result.ErrorMessage))
            {
                return NotFound(result.ErrorMessage);
            }

            return Ok(result.Product);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Webshop.API.Models.Request;
using Webshop.API.Services;

namespace Webshop.API.Controllers
{
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ShoppingCartService _shoppingCartService;

        public ShoppingCartController(ShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        /// <summary>
        /// Adds a new product to the shopping cart.
        /// </summary>
        /// <param name="cartId">Shopping cart Id</param>
        /// <param name="productRequest">Product request containing the product Id and the quantity of the product.</param>
        /// <returns></returns>
        [HttpPut("ShoppingCart/{cartId}/Product")]
        public async Task<IActionResult> AddProduct([FromRoute] string cartId, [FromBody] ProductRequestModel productRequest)
        {
            var errorMessage = await _shoppingCartService.AddProduct(cartId, productRequest);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return NotFound(errorMessage);
            }

            return Accepted();
        }

        /// <summary>
        /// Gets the shopping cart summary, including SubTotal, Discount, Total, shopping items.
        /// </summary>
        /// <param name="cartId">Shopping cart Id</param>
        /// <returns>Shopping cart summary</returns>
        [HttpGet("ShoppingCart/{cartId}")]
        public async Task<IActionResult> Get([FromRoute] string cartId)
        {
            var cart = await _shoppingCartService.Get(cartId);
            return Ok(cart);
        }
    }
}

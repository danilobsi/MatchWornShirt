using Webshop.API.Models.Request;
using Webshop.API.Models.View;
using Webshop.API.Repositories;

namespace Webshop.API.Services
{
    public class ShoppingCartService
    {
        private readonly IShoppingCartItemRepository _cartItemRepository;
        private readonly IProductRepository _productRepository;
        private readonly IEnumerable<IDiscountService> _discountServices;

        public ShoppingCartService(IShoppingCartItemRepository shoppingCartItemRepository, IProductRepository productRepository, IEnumerable<IDiscountService> discountServices)
        {
            _cartItemRepository = shoppingCartItemRepository;
            _productRepository = productRepository;
            _discountServices = discountServices;
        }

        public async Task<string> AddProduct(string shoppingCartId, ProductRequestModel productRequest)
        {
            var product = await _productRepository.Get(productRequest.ProductId);
            if (product == null)
            {
                return $"The product Id '{productRequest.ProductId}' was not found.";
            }

            //TODO: If the Quantity is negative, remove an item from the cart
            for (int i = 0; i < productRequest.Quantity; i++)
            {
                await _cartItemRepository.Add(productRequest.ProductId, shoppingCartId);
            }
            return string.Empty;
        }

        public async Task<ShoppingCartSummaryModel> Get(string cartId)
        {
            decimal subtotal = 0;
            var cart = new ShoppingCartSummaryModel();
            var items = (await _cartItemRepository.GetBy(cartId))
                .GroupBy(i => i.ProductId)
                .Select(g => new ShoppingCartItemViewModel
                {
                    ProductID = g.Key,
                    Quantity = g.Count()
                });

            foreach (var item in items)
            {
                var product = await _productRepository.Get(item.ProductID);
                if (product == null)
                {
                    continue;
                }

                item.Product = product;
                item.Total = product.Price * item.Quantity;

                cart.Items.Add(item);
                subtotal += item.Total;
            }

            cart.SubTotal = Math.Round(subtotal, 2);
            cart.Discount = Math.Round(CalculateDiscount(cart.Items), 2);

            cart.Total = cart.SubTotal - cart.Discount;

            return cart;
        }

        /// <summary>
        /// Calculates the total discount for the shopping cart
        /// </summary>
        private decimal CalculateDiscount(List<ShoppingCartItemViewModel> items)
        {
            var discountTasks = new List<Task<decimal>>();
            foreach (var discountService in _discountServices)
            {
                discountTasks.Add(discountService.Calculate(items));
            }

            return Task.WhenAll(discountTasks).Result.Sum();
        }
    }
}

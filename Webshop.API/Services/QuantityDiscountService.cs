using Webshop.API.Models.View;

namespace Webshop.API.Services
{
    public class QuantityDiscountService : IDiscountService
    {
        /// <summary>
        /// If a customer gets more than 2 Kylian Mbappé's T-shirts, they get 1 free for each 2 in the cart.
        /// </summary>
        /// <param name="items">Cart Items</param>
        /// <returns>Discount, if any</returns>
        public async Task<decimal> Calculate(List<ShoppingCartItemViewModel> items)
        {
            var item = items.FirstOrDefault(i => i.ProductID == 1 && i.Quantity > 2);
            if (item != null)
            {
                return (int)(item.Quantity / 2) * item.Product.Price;
            }

            return 0;
        }
    }
}

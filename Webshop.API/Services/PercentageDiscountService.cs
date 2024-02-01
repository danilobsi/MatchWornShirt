using Webshop.API.Models.View;

namespace Webshop.API.Services
{
    public class PercentageDiscountService : IDiscountService
    {
        /// <summary>
        /// If a customer gets more than 2 Bart van Hintum's T-shirts, they get 20% off on all Bart van Hintum's T-shirts in the cart.
        /// </summary>
        /// <param name="items">Cart Items</param>
        /// <returns>Discount, if any</returns>
        public async Task<decimal> Calculate(List<ShoppingCartItemViewModel> items)
        {
            var item = items.FirstOrDefault(i => i.ProductID == 3 && i.Quantity > 2);
            if (item != null)
            {
                return item.Quantity * item.Product.Price * (decimal)0.2;
            }

            return 0;
        }
    }
}

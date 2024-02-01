using Webshop.API.Models.View;

namespace Webshop.API.Services
{
    public class CashDiscountService : IDiscountService
    {
        /// <summary>
        /// If a customer gets an Olivier Giroud's T-shirt and a Thom van Bergen's T-shirt, they get $5 off the order total.
        /// </summary>
        /// <param name="items">Cart Items</param>
        /// <returns>Discount, if any</returns>
        public async Task<decimal> Calculate(List<ShoppingCartItemViewModel> items)
        {
            var productIds = items.Select(i => i.ProductID);
            if (productIds.Contains(2) && productIds.Contains(4))
            {
                return 5;
            }

            return 0;
        }
    }
}

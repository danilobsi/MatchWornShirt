using Webshop.API.Models.View;

namespace Webshop.API.Services
{
    public interface IDiscountService
    {
        Task<decimal> Calculate(List<ShoppingCartItemViewModel> items);
    }
}

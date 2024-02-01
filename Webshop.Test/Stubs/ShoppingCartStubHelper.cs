using Moq;
using Webshop.API.Models.Data;
using Webshop.API.Repositories;

namespace Webshop.Test.Stubs
{
    public static class ShoppingCartStubHelper
    {
        public static Mock<IShoppingCartItemRepository> AddProducts(this Mock<IShoppingCartItemRepository> mock, string cartId, params int[] productIds)
        {
            var cartItems = new List<ShoppingCartItemDataModel>(productIds.Length);
            foreach (var productId in productIds)
            {
                cartItems.Add(new ShoppingCartItemDataModel
                {
                    ShoppingCartId = cartId,
                    ProductId = productId,
                });
            }
            mock.Setup(s => s.GetBy(cartId)).ReturnsAsync(cartItems);
            return mock;
        }
    }
}

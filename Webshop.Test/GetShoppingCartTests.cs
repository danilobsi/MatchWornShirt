using Moq;
using Webshop.API.Repositories;
using Webshop.API.Services;
using Webshop.Test.Stubs;

namespace Webshop.Test
{
    public class GetShoppingCartTests
    {
        private readonly ShoppingCartService _shoppingCartService;
        private readonly Mock<IShoppingCartItemRepository> _cartItemRepositoryMock;
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly IEnumerable<IDiscountService> _discountServices;

        public GetShoppingCartTests()
        {
            _cartItemRepositoryMock = new Mock<IShoppingCartItemRepository>();
            _productRepositoryMock = new Mock<IProductRepository>();

            _productRepositoryMock.AddProduct(1, "Kylian Mbappé's T-shirt", (decimal)100.99);
            _productRepositoryMock.AddProduct(2, "Olivier Giroud's T-shirt", (decimal)200.49);
            _productRepositoryMock.AddProduct(3, "Bart van Hintum's T-shirt", (decimal)110.99);
            _productRepositoryMock.AddProduct(4, "Thom van Bergen's T-shirt", (decimal)160.99);

            _discountServices = new List<IDiscountService>
            {
                new QuantityDiscountService(),
                new PercentageDiscountService(),
                new CashDiscountService()
            };

            _shoppingCartService = new ShoppingCartService(_cartItemRepositoryMock.Object, _productRepositoryMock.Object, _discountServices);
        }

        [Theory]
        [InlineData("cart1", 362.97, 1, 1, 4)]                       //cart 1: [2x "Kylian Mbappé's T-shirt", 1x "Thom van Bergen's T-shirt"] -> $362.97
        [InlineData("cart2", 574.95, 1, 1, 1, 1, 1, 4, 3)]           //cart 2: [5x "Kylian Mbappé's T-shirt", 1x "Thom van Bergen's T-shirt", 1x "Bart van Hintum's T-shirt"] -> $574.95
        [InlineData("cart3", 1111.32, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3)] //cart 3: [2x "Olivier Giroud's T-shirt", 8x "Bart van Hintum's T-shirt"] -> $1111.32
        [InlineData("cart4", 568.46, 1, 2, 3, 4)]                    //cart 4: [1x "Kylian Mbappé's T-shirt", 1x "Bart van Hintum's T-shirt", 1x "Olivier Giroud's T-shirt", 1x "Thom van Bergen's T-shirt"] -> $568.46
        [InlineData("cart5", 758.95, 1, 1, 1, 2, 2, 4)]              //cart 5: [3x "Kylian Mbappé's T-shirt", 2x "Olivier Giroud's T-shirt", 1x "Thom van Bergen's T-shirt"] -> $758.95
        public async Task GetShoppingCartTests_Cart1(string cartId, decimal expectedTotal, params int[] productIds)
        {
            // Arrange
            _cartItemRepositoryMock.AddProducts(cartId, productIds);

            // Act
            var cart = await _shoppingCartService.Get(cartId);

            // Assert
            Assert.Equal(expectedTotal, cart.Total);
        }
    }
}
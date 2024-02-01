using Moq;
using Webshop.API.Models.View;
using Webshop.API.Repositories;

namespace Webshop.Test.Stubs
{
    public static class ProductRepositoryStubHelper
    {
        public static Mock<IProductRepository> AddProducts(this Mock<IProductRepository> mock, int id, string name, decimal price)
        {
            mock.Setup(p => p.Get(id)).ReturnsAsync(new ProductViewModel
            {
                Id = id,
                Name = name,
                Price = price
            });
            return mock;
        }
    }
}

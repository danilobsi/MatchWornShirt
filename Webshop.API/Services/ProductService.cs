using Webshop.API.Models.View;
using Webshop.API.Models;
using Webshop.API.Repositories;

namespace Webshop.API.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<PagingModel<ProductViewModel>> GetAll(int page, int pageSize)
        {
            return _productRepository.GetAll(page, pageSize);
        }

        public async Task<(string ErrorMessage, ProductViewModel? Product)> Get(int id)
        {
            var product = await _productRepository.Get(id);
            if (product == null)
            {
                return ($"The product {id} was not found.", null);
            }

            return (string.Empty, product);
        }
    }
}

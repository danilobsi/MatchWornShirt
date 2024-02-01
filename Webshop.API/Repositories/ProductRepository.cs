using Webshop.API.Models;
using Webshop.API.Models.Data;
using Webshop.API.Models.View;

namespace Webshop.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public ProductRepository()
        {
            using (var context = new ApiContext())
            {
                context.Products.AddRange(
                    new ProductDataModel
                    {
                        Id = 1,
                        Name = "Kylian Mbappé's T-shirt",
                        Price = (decimal)100.99
                    },
                    new ProductDataModel
                    {
                        Id = 2,
                        Name = "Olivier Giroud's T-shirt",
                        Price = (decimal)200.49
                    },
                    new ProductDataModel
                    {
                        Id = 3,
                        Name = "Bart van Hintum's T-shirt",
                        Price = (decimal)110.99
                    },
                    new ProductDataModel
                    {
                        Id = 4,
                        Name = "Thom van Bergen's T-shirt",
                        Price = (decimal)160.99
                    });
                context.SaveChanges();
            }
        }

        public async Task<PagingModel<ProductViewModel>> GetAll(int page, int pageSize)
        {
            using (var context = new ApiContext())
            {
                return PagingModel<ProductViewModel>.Create(page, pageSize, context.Products.Select(ProductViewModel.Create()).OrderBy(p => p.Name));
            }
        }

        public async Task<ProductViewModel?> Get(int id)
        {
            using (var context = new ApiContext())
            {
                return context.Products.Select(ProductViewModel.Create()).FirstOrDefault(p => p.Id == id);
            }
        }
    }

    public interface IProductRepository
    {
        Task<PagingModel<ProductViewModel>> GetAll(int page, int pageSize);
        Task<ProductViewModel?> Get(int id);
    }
}

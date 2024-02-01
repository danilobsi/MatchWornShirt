using System.Linq.Expressions;
using Webshop.API.Models.Data;

namespace Webshop.API.Models.View
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public static Expression<Func<ProductDataModel, ProductViewModel>> Create()
        {
            return (product) => new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }
    }
}

using Webshop.API.Models.Data;

namespace Webshop.API.Repositories
{
    public class ShoppingCartItemRepository: IShoppingCartItemRepository
    {
        public async Task<IEnumerable<ShoppingCartItemDataModel>> GetBy(string shoppingCartId)
        {
            using (var context = new ApiContext())
            {
                return context.ShoppingCartItems.Where(s => s.ShoppingCartId == shoppingCartId).ToList();
            }
        }

        public Task Add(int productId, string shoppingCartId)
        {
            using (var context = new ApiContext())
            {
                context.ShoppingCartItems.Add(new ShoppingCartItemDataModel
                {
                    ProductId = productId,
                    ShoppingCartId = shoppingCartId
                });
                context.SaveChanges();
                return Task.CompletedTask;
            }
        }
    }

    public interface IShoppingCartItemRepository
    {
        Task<IEnumerable<ShoppingCartItemDataModel>> GetBy(string shoppingCartId);
        Task Add(int productId, string shoppingCartId);
    }
}

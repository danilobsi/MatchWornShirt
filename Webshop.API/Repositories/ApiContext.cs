using Microsoft.EntityFrameworkCore;
using Webshop.API.Models.Data;

namespace Webshop.API.Repositories
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "WebShopDb");
        }
        public DbSet<ProductDataModel> Products { get; set; }
        public DbSet<ShoppingCartItemDataModel> ShoppingCartItems { get; set; }
    }
}

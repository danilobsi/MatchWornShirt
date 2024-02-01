using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Webshop.API.Models.Data
{
    public class ShoppingCartItemDataModel
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ShoppingCartId { get; set; }
    }
}

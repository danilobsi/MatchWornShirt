namespace Webshop.API.Models.View
{
    public class ShoppingCartItemViewModel
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public ProductViewModel Product { get; set; }
    }
}

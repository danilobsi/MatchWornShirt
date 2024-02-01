namespace Webshop.API.Models.View
{
    public class ShoppingCartSummaryModel
    {
        public List<ShoppingCartItemViewModel> Items { get; set; } = new List<ShoppingCartItemViewModel>();
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
    }
}

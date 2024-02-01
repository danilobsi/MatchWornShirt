namespace Webshop.API.Models.Request
{
    /// <summary>
    /// Product request to add items to the shopping cart
    /// </summary>
    public class ProductRequestModel
    {
        /// <summary>
        /// Product's Id to be added to the shopping cart
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// PRoduct's quantity to be added to the shopping cart
        /// </summary>
        public int Quantity { get; set; }
    }
}

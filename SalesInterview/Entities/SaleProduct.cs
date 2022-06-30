namespace SalesInterview.Entities
{
    public class SaleProduct
    {
        public int ProductId { get; set; }
        public int SaleId { get; set; }
        public Sale Sale { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
    }
}

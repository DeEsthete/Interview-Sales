namespace SalesInterview.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string UserEmail { get; set; }
        public ICollection<SaleProduct> Products { get; set; }
    }
}

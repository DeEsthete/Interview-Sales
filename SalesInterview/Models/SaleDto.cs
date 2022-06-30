namespace SalesInterview.Models
{
    public class SaleDto
    {
        public string UserEmail { get; set; }
        public List<SaleProductDto> Products { get; set; }
    }
}

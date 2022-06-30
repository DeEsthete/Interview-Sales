using Microsoft.AspNetCore.Mvc;
using SalesInterview.Data;
using SalesInterview.Entities;
using SalesInterview.Models;

namespace SalesInterview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public IActionResult GetProducts(string? category, string? color, string? size)
        {
            var products = MockDataHelper.GenerateProducts(10).AsEnumerable();

            if (!string.IsNullOrWhiteSpace(category))
            {
                products = products.Where(p => p.Category == category);
            }

            if (!string.IsNullOrWhiteSpace(color))
            {
                products = products.Where(p => p.Color == color);
            }

            if (!string.IsNullOrWhiteSpace(size))
            {
                products = products.Where(p => p.Size == size);
            }

            return Ok(products.ToList());
        }

        [HttpPost("sale")]
        public async Task<IActionResult> CreateSale(SaleDto saleDto)
        {
            if (saleDto.Products.Count == 0)
            {
                return BadRequest("Products can't be empty");
            }

            if (saleDto.Products.Any(p => p.Quantity <= 0))
            {
                return BadRequest("Product quantity must be greater than 0");
            }

            var entity = new Sale()
            {
                Date = DateTime.UtcNow,
                UserEmail = saleDto.UserEmail,
                Products = saleDto.Products.ConvertAll(p => new SaleProduct()
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Category = p.Category,
                    Color = p.Color,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    Size = p.Size
                }),
            };

            await _context.Sales.AddAsync(entity);
            await _context.SaveChangesAsync();

            var total = entity.Products.Sum(p => p.Price * p.Quantity);
            return Ok(total);
        }
    }
}

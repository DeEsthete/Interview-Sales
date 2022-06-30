using SalesInterview.Models;

namespace SalesInterview.Data
{
    public static class MockDataHelper
    {
        private static readonly string[] Names = new string[] { "Hat", "Pants", "Shirt", "Boots" };
        private static readonly string[] Categories = new string[] { "Men", "Women", "Kids" };
        private static readonly string[] Colors = new string[] { "Pink", "Red", "Blue" };
        private static readonly string[] Sizes = new string[] { "M", "L", "X" };

        public static List<ProductDto> GenerateProducts(int count)
        {
            var random = new Random();

            return Enumerable.Range(1, count).Select(n => new ProductDto()
            {
                ProductId = n,
                ProductName = $"{Names[random.Next(Names.Length)]} {n}",
                Category = Categories[random.Next(Categories.Length)],
                Color = Colors[random.Next(Colors.Length)],
                Size = Sizes[random.Next(Sizes.Length)],
                Price = random.Next(1, 9) * 10
            }).ToList();
        }
    }
}

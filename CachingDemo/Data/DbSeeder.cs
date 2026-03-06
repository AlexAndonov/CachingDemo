using CachingDemo.Models;

namespace CachingDemo.Data
{
	public static class DbSeeder
	{
		public static async Task SeedAsync(AppDbContext context)
		{
			if (context.Products.Any())
			{
				return;
			}

			var products = new List<Product>();

			for (int i = 1; i <= 100000; i++)
			{
				products.Add(new Product
				{
					Name = $"Product {i}",
					Price = Random.Shared.Next(1, 1000)
				});
			}

			await context.Products.AddRangeAsync(products);
			await context.SaveChangesAsync();
		}
	}
}

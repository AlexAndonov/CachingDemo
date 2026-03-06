using CachingDemo.Common;
using CachingDemo.Data;
using CachingDemo.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace CachingDemo.Services
{
	public class ProductService
	{
		private readonly AppDbContext context;
		private readonly IMemoryCache cache;
		private readonly ILogger<ProductService> logger;

		public ProductService(AppDbContext _context, IMemoryCache _cache, ILogger<ProductService> _logger)
		{
			context = _context;
			cache = _cache;
			logger = _logger;
		}

		public async Task<List<Product>> GetProducts()
		{
			var cacheKey = CacheKeys.Products;

			if (cache.TryGetValue(cacheKey, out List<Product>? cachedProducts))
			{
				logger.LogInformation("CACHE HIT");
				return cachedProducts;
			}

			logger.LogInformation("CACHE MISS - fetch data from database");

			var products = await context.Products.ToListAsync();

			var cacheOptions = new MemoryCacheEntryOptions()
				.SetAbsoluteExpiration(TimeSpan.FromMinutes(5))
				.SetSlidingExpiration(TimeSpan.FromMinutes(2));

			cache.Set(cacheKey, products, cacheOptions);

			return products;
		}

		public async Task Create(Product product)
		{
			await context.Products.AddAsync(product);
			await context.SaveChangesAsync();

			cache.Remove(CacheKeys.Products);

			logger.LogInformation("CACHE INVALIDATED - products");
		}
	}
}

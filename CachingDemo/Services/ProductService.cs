using CachingDemo.Common;
using CachingDemo.Data;
using CachingDemo.Models;
using CachingDemo.Services.Caching;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace CachingDemo.Services
{
	public class ProductService
	{
		private readonly AppDbContext context;
		private readonly ILogger<ProductService> logger;
		private readonly ICacheService cacheService;

		public ProductService(AppDbContext _context, ILogger<ProductService> _logger, ICacheService _cacheService)
		{
			context = _context;
			logger = _logger;
            cacheService = _cacheService;
		}

		public async Task<List<Product>> GetProducts()
		{
            var cachedProducts = await cacheService.GetAsync<List<Product>>(CacheKeys.Products);

            if (cachedProducts != null)
            {
                logger.LogInformation("Cache HIT");
                return cachedProducts;
            }

            logger.LogInformation("Cache MISS");

            var products = await context.Products.ToListAsync();

            var options = new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            };

            await cacheService.SetAsync(
                    CacheKeys.Products,
                    products,
                    TimeSpan.FromMinutes(5));

            return products;
        }

		public async Task Create(Product product)
		{
			await context.Products.AddAsync(product);
			await context.SaveChangesAsync();

            await cacheService.RemoveAsync(CacheKeys.Products);

            logger.LogInformation("CACHE INVALIDATED - products");
		}
	}
}

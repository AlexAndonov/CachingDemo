using CachingDemo.Models;
using CachingDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace CachingDemo.Controllers
{
	[ApiController]
	[Route("api/products")]
	public class ProductController : ControllerBase
	{
		private readonly ProductService service;

		public ProductController(ProductService _service)
		{
			service = _service;
		}

		[HttpGet]
		public async Task<IActionResult> GetProducts()
		{
			var products = await service.GetProducts();

			return Ok(products);
		}

		[HttpPost]
		public async Task<IActionResult> Create(Product product)
		{
			await service.Create(product);
			return Ok(product);
		}
	}
}

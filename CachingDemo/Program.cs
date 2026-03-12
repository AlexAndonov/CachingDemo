
using CachingDemo.Data;
using CachingDemo.Services;
using CachingDemo.Services.Caching;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CachingDemo
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllers();
			builder.Services.AddOpenApi();

			builder.Services.AddDbContext<AppDbContext>(options =>
					options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			builder.Services.AddScoped<ProductService>();
            builder.Services.AddScoped<ICacheService, RedisCacheService>();

            builder.Services.AddStackExchangeRedisCache(options =>
			{
				options.Configuration = "localhost:6379";
				options.InstanceName = "CachingDemo_";
			});

			var app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				app.MapOpenApi();
			}

			using (var scope = app.Services.CreateScope())
			{
				var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

				await DbSeeder.SeedAsync(context);
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}

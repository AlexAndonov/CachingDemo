using CachingDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CachingDemo.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Product>()
				.Property(p => p.Price)
				.HasPrecision(18, 2);
		}

		public DbSet<Product> Products { get; set; }

	}
}

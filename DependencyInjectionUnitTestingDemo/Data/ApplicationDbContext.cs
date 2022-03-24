using DependencyInjectionUnitTestingDemo.Models.Sales;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DependencyInjectionUnitTestingDemo.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public DbSet<BasicPrice> BasicPrices { get; set; }

		public DbSet<Customer> Customers { get; set; }

		public DbSet<CustomerPrice> CustomerPrices { get; set; }

		public DbSet<CustomerProductGroupDiscount> CustomerProductGroupDiscounts { get; set; }

		public DbSet<Product> Products { get; set; }

		public DbSet<ProductGroup> ProductGroups { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			// Customize the ASP.NET Identity model and override the defaults if needed.
			// For example, you can rename the ASP.NET Identity table names and more.
			// Add your customizations after calling base.OnModelCreating(builder);

			builder.Entity<BasicPrice>().HasKey(e => e.BasicPriceId);
			builder.Entity<Customer>().HasKey(e => e.CustomerId);
			builder.Entity<CustomerPrice>().HasKey(e => e.CustomerPriceId);
			builder.Entity<CustomerProductGroupDiscount>().HasKey(e => e.CustomerProductGroupDiscountId);
			builder.Entity<Product>().HasKey(e => e.ProductId);
			builder.Entity<ProductGroup>().HasKey(e => e.ProductGroupId);
		}
	}
}
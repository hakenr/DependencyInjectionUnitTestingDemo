using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DependencyInjectionUnitTestingDemo.Models;
using DependencyInjectionUnitTestingDemo.Models.Sales;
using DependencyInjectionUnitTestingDemo.Data;

namespace DependencyInjectionUnitTestingDemo.Repositories.Sales
{
	public class ProductRepository : IProductRepository
	{
		private readonly ApplicationDbContext applicationDbContext;

		public ProductRepository(ApplicationDbContext applicationDbContext)
		{
			this.applicationDbContext = applicationDbContext;
		}

		public IEnumerable<Product> GetAll()
		{
			return applicationDbContext.Products.ToList();
		}

		public Product GetObject(int productId)
		{
			return applicationDbContext.Products
				.Include(p => p.ProductGroup)
				.SingleOrDefault(p => p.ProductId == productId);
		}
	}
}
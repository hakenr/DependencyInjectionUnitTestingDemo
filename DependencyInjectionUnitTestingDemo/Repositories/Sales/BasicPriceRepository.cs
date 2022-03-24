using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using DependencyInjectionUnitTestingDemo.Data;
using DependencyInjectionUnitTestingDemo.Models;
using DependencyInjectionUnitTestingDemo.Models.Sales;
using DependencyInjectionUnitTestingDemo.Repositories.Sales;

namespace DependencyInjectionUnitTestingDemo.Repositories.Sales
{
	public class BasicPriceRepository : IBasicPriceRepository
	{
		private readonly ApplicationDbContext applicationDbContext;

		public BasicPriceRepository(ApplicationDbContext applicationDbContext)
		{
			this.applicationDbContext = applicationDbContext;
		}

		public decimal? GetBasicPriceForProduct(Product product)
		{
			return applicationDbContext.BasicPrices.SingleOrDefault(p => p.Product.ProductId == product.ProductId)?.Price;
		}
	}
}
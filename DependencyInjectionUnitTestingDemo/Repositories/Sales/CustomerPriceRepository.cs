using System;
using System.Collections.Generic;
using System.Linq;
using DependencyInjectionUnitTestingDemo.Data;
using DependencyInjectionUnitTestingDemo.Models;
using DependencyInjectionUnitTestingDemo.Models.Sales;
using DependencyInjectionUnitTestingDemo.Repositories.Sales;

namespace DependencyInjectionUnitTestingDemo.Repositories.Sales
{
	public class CustomerPriceRepository : ICustomerPriceRepository
	{
		private readonly ApplicationDbContext applicationDbContext;

		public CustomerPriceRepository(ApplicationDbContext applicationDbContext)
		{
			this.applicationDbContext = applicationDbContext;
		}

		public decimal? GetCustomerPrice(Customer customer, Product product)
		{
			return applicationDbContext.CustomerPrices.SingleOrDefault(p => p.Customer.CustomerId == customer.CustomerId && p.Product.ProductId == product.ProductId)?.Price;
		}
	}
}
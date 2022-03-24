using System;
using System.Collections.Generic;
using System.Linq;
using DependencyInjectionUnitTestingDemo.Models.Sales;

namespace DependencyInjectionUnitTestingDemo.Repositories.Sales
{
	public interface IProductRepository
	{
		IEnumerable<Product> GetAll();

		Product GetObject(int productId);
	}
}
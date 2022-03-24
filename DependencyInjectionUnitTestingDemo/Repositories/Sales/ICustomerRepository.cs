using System;
using System.Collections.Generic;
using System.Linq;
using DependencyInjectionUnitTestingDemo.Models.Sales;

namespace DependencyInjectionUnitTestingDemo.Repositories.Sales
{
	public interface ICustomerRepository
	{
		IEnumerable<Customer> GetAll();

		Customer GetObject(int customerId);
	}
}
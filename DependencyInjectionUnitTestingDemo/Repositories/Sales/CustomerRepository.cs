using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using DependencyInjectionUnitTestingDemo.Data;
using DependencyInjectionUnitTestingDemo.Models;
using DependencyInjectionUnitTestingDemo.Models.Sales;

namespace DependencyInjectionUnitTestingDemo.Repositories.Sales
{
	public class CustomerRepository : ICustomerRepository
	{
		private readonly ApplicationDbContext applicationDbContext;

		public CustomerRepository(ApplicationDbContext applicationDbContext)
		{
			this.applicationDbContext = applicationDbContext;
		}

		public IEnumerable<Customer> GetAll()
		{
			return applicationDbContext.Customers.ToList();
		}

		public Customer GetObject(int customerId)
		{
			return applicationDbContext.Customers.SingleOrDefault(c => c.CustomerId == customerId);
		}
	}
}
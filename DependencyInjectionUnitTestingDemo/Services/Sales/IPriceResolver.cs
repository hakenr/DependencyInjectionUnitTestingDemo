using System;
using DependencyInjectionUnitTestingDemo.Models.Sales;

namespace DependencyInjectionUnitTestingDemo.Services.Sales
{
	public interface IPriceResolver
	{
		decimal? GetPrice(Customer customer, Product product);
	}
}
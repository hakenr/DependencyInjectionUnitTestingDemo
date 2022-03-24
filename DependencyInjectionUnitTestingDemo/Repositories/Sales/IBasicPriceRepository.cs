using System;
using System.Collections.Generic;
using System.Linq;
using DependencyInjectionUnitTestingDemo.Models.Sales;

namespace DependencyInjectionUnitTestingDemo.Repositories.Sales
{
	public interface IBasicPriceRepository
	{
		decimal? GetBasicPriceForProduct(Product product);
	}
}
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DependencyInjectionUnitTestingDemo.Services.Sales
{
	public interface ICustomerSelectOptions
	{
		IEnumerable<SelectListItem> GetSelectListItems();
	}
}
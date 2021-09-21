using Microsoft.AspNetCore.Mvc;

namespace Warehouse.Controllers
{
	public class ItemController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

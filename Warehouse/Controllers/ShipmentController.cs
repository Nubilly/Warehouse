using Microsoft.AspNetCore.Mvc;

namespace Warehouse.Controllers
{
	public class ShipmentController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

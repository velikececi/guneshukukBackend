using Microsoft.AspNetCore.Mvc;

namespace guneshukuk.WebUI.Controllers
{
	public class UILayoutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

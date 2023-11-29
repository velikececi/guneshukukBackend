using Microsoft.AspNetCore.Mvc;

namespace guneshukuk.WebUI.Controllers
{
	public class DefaultController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

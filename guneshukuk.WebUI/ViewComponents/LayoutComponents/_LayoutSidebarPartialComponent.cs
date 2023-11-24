using Microsoft.AspNetCore.Mvc;

namespace guneshukuk.WebUI.ViewComponents.LayoutComponents
{
	public class _LayoutSidebarPartialComponent:ViewComponent
	{

		public IViewComponentResult Invoke ()
		{
			return View();
		}
	}
}

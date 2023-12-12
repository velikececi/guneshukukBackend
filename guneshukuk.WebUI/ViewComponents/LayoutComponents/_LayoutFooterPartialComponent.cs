using Microsoft.AspNetCore.Mvc;

namespace guneshukuk.WebUI.ViewComponents.LayoutComponents
{
    public class _LayoutFooterPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

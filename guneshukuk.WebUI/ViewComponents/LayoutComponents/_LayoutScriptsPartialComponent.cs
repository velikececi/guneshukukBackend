using Microsoft.AspNetCore.Mvc;

namespace guneshukuk.WebUI.ViewComponents.LayoutComponents
{
    public class _LayoutScriptsPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace guneshukuk.WebUI.ViewComponents.LayoutComponents
{
    public class _LayoutHeaderPartialComponent:ViewComponent
    {
        public  IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

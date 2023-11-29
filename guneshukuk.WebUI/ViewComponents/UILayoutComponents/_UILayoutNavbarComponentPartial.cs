using Microsoft.AspNetCore.Mvc;

namespace guneshukuk.WebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutNavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
              return View();
         }
    }
}

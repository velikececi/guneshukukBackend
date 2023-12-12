using Microsoft.AspNetCore.Mvc;

namespace guneshukuk.WebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutHeaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

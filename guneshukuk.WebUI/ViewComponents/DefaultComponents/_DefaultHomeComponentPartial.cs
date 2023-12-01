using Microsoft.AspNetCore.Mvc;

namespace guneshukuk.WebUI.ViewComponents.DefaultComponents
{
    public class _DefaultHomeComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        { 
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace guneshukuk.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Demo.WebAdmin.Controllers
{
    public class WarhousesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

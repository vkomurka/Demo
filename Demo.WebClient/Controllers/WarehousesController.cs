using Microsoft.AspNetCore.Mvc;

namespace Demo.WebClient.Controllers
{
    public class WarehousesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

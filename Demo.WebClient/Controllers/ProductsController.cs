using Microsoft.AspNetCore.Mvc;

namespace Demo.WebClient.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

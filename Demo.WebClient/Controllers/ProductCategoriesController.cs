using Microsoft.AspNetCore.Mvc;

namespace Demo.WebClient.Controllers
{
    public class ProductCategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Demo.Contracts.Dtos;
using Demo.WebClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.WebClient.Controllers
{
    public class UomsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(UomsService.Uoms);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UomDto uom)
        {
            uom.Id = Guid.NewGuid();
            UomsService.Uoms.Add(uom);
            return RedirectToAction(nameof(Index));
        }
    }
}

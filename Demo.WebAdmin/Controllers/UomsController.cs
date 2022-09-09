using Demo.Contracts;
using Demo.Contracts.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Demo.WebAdmin.Controllers
{
    public class UomsController : Controller
    {
        public DemoClient DemoClient { get; }

        public UomsController(DemoClient demoClient)
        {
            DemoClient = demoClient ?? throw new ArgumentNullException(nameof(demoClient));
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await DemoClient.Uoms.GetUomsAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UomDto uom)
        {
            if (ModelState.IsValid)
            {
                uom.Id = Guid.NewGuid();
                await DemoClient.Uoms.PostUomsAsync(new List<UomDto> { uom });
                TempData["message"] = "Uom created successfully.";
                return RedirectToAction("Index");
            }
            return View(uom);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if ((id == null) || (id == Guid.Empty))
            {
                return NotFound();
            }
            var uom = await DemoClient.Uoms.GetUomAsync((Guid)id);

            if (uom == null)
            {
                return NotFound();
            }
            return View(uom);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UomDto uom)
        {
            if (ModelState.IsValid)
            {
                await DemoClient.Uoms.PutUomsAsync(new List<UomDto> { uom });
                TempData["message"] = "Uom updated successfully.";
                return RedirectToAction("Index");
            }
            return View(uom);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if ((id == null) || (id == Guid.Empty))
            {
                return NotFound();
            }
            var uom = await DemoClient.Uoms.GetUomAsync((Guid)id);

            if (uom == null)
            {
                return NotFound();
            }
            return View(uom);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(UomDto uom)
        {
            await DemoClient.Uoms.DeleteUomAsync(uom.Id);
            TempData["message"] = "Uom deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}

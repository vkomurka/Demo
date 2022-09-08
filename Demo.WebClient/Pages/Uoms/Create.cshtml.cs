using Demo.ClientServices;
using Demo.Contracts.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.WebClient.Pages.Uoms;

[BindProperties]
public class CreateModel : PageModel
{
    public UomDto Uom { get; set; }

    public void OnGet()
    {
        Uom = new UomDto() { Id = Guid.NewGuid() };
    }

    public async Task<IActionResult> OnPost(UomDto uom)
    {
        if (uom.Code == "aaa" )
        {
            ModelState.AddModelError(string.Empty, "Not be 'aaa'.");
        }

        if (ModelState.IsValid)
        {
            uom.Id = Guid.NewGuid();
            var uomService = new UomService();
            await uomService.AddUoms(new List<UomDto>() { uom });
            TempData["success"] = "Uom created successfully";

            return RedirectToPage("Index");
        }
        return Page();
    }
}
using Demo.ClientServices;
using Demo.Contracts.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.WebClient.Pages.Uoms;

[BindProperties]
public class EditModel : PageModel
{
    public UomDto Uom { get; set; }

    public async Task OnGetAsync(Guid id)
    {
        var uomService = new UomService();
        var uoms = await uomService.FindUom(id);
        Uom = uoms.FirstOrDefault();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (Uom.Code == "aaa")
        {
            ModelState.AddModelError(string.Empty, "Not be 'aaa'.");
        }

        if (ModelState.IsValid)
        {
            var uomService = new UomService();
            await uomService.PutUoms(new List<UomDto>() { Uom });
            TempData["success"] = "Uom updated successfully";

            return RedirectToPage("Index");
        }
        return Page();
    }
}
using Demo.ClientServices;
using Demo.Contracts.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.WebClient.Pages.Uoms;

[BindProperties]
public class DeleteModel : PageModel
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
        var uomService = new UomService();
        await uomService.DeleteUom(Uom.Id);
        TempData["success"] = "Uom deleted successfully";

        return RedirectToPage("Index");
    }
}
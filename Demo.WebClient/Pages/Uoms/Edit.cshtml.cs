using Demo.Contracts;
using Demo.Contracts.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.WebClient.Pages.Uoms;

[BindProperties]
public class EditModel : PageModel
{
    public DemoClient Client { get; }
    public UomDto Uom { get; set; }

    public EditModel(DemoClient client)
    {
        Client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public async Task OnGetAsync(Guid id)
    {
        Uom = await Client.Uoms.GetUomAsync(id);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (Uom.Code == "aaa")
        {
            ModelState.AddModelError(string.Empty, "Not be 'aaa'.");
        }

        if (ModelState.IsValid)
        {
            await Client.Uoms.PutUomsAsync(new List<UomDto>() { Uom });
            TempData["success"] = "Uom updated successfully";

            return RedirectToPage("Index");
        }
        return Page();
    }
}
using Demo.Contracts;
using Demo.Contracts.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.WebClient.Pages.Uoms;

[BindProperties]
public class DeleteModel : PageModel
{
    public DemoClient Client { get; }
    public UomDto Uom { get; set; }

    public DeleteModel(DemoClient client)
    {
        Client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public async Task OnGetAsync(Guid id)
    {
        Uom = await Client.Uoms.GetUomAsync(id);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await Client.Uoms.DeleteUomAsync(Uom.Id);
        TempData["success"] = "Uom deleted successfully";

        return RedirectToPage("Index");
    }
}
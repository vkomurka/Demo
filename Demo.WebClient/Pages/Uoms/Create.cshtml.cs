using Demo.Contracts;
using Demo.Contracts.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.WebClient.Pages.Uoms;

[BindProperties]
public class CreateModel : PageModel
{
    public DemoClient Client { get; }
    public UomDto Uom { get; set; }

    public CreateModel(DemoClient client)
    {
        Client = client ?? throw new ArgumentNullException(nameof(client));
    }

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
            await Client.Uoms.PostUomsAsync(new List<UomDto>() { uom });
            TempData["success"] = "Uom created successfully";

            return RedirectToPage("Index");
        }
        return Page();
    }
}
using Demo.ClientServices;
using Demo.Contracts.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.WebClient.Pages.Uoms;

[BindProperties]
public class IndexModel : PageModel
{
    public List<UomDto> Uoms { get; set; }

    public async Task OnGetAsync()
    {
        var uomService = new UomService();
        Uoms = await uomService.LoadUoms();
    }
}
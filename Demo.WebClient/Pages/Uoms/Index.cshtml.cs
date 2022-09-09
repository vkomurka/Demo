using Demo.Contracts;
using Demo.Contracts.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.WebClient.Pages.Uoms;

[BindProperties]
public class IndexModel : PageModel
{
    public DemoClient Client { get; }
    public List<UomDto> Uoms { get; set; }

    public IndexModel(DemoClient client)
    {
        Client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public async Task OnGetAsync()
    {
        Uoms = await Client.Uoms.GetUomsAsync();
    }
}
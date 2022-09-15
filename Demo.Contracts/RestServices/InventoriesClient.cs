using Demo.Contracts.Dtos;
using RestSharp;

namespace Demo.Contracts.RestServices;

public class InventoriesClient : RestService
{
    public InventoriesClient() : base()
    {
    }

    public InventoriesClient(RestClient client) : base(client)
    {
    }

    private const string C_Inventories = "Inventories";

    public async Task<List<InventoryDto>> GetAsync()
    {
        var request = new RestRequest(C_Inventories);
        return await Client.GetAsync<List<InventoryDto>>(request);
    }

    public async Task<InventoryDto> GetAsync(Guid id)
    {
        var request = new RestRequest(C_Inventories + "/" + id);
        return await Client.GetAsync<InventoryDto>(request);
    }
}
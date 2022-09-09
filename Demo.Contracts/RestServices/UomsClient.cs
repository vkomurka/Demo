using Demo.Contracts.Dtos;
using RestSharp;

namespace Demo.Contracts.RestServices;

public class UomsClient : RestService
{
    public UomsClient() : base()
    {
    }

    public UomsClient(RestClient client) : base(client)
    {
    }

    private const string C_Uoms = "uoms";

    public async Task<List<UomDto>> GetUomsAsync()
    {
        var request = new RestRequest(C_Uoms);
        return await Client.GetAsync<List<UomDto>>(request);
    }

    public async Task<UomDto> GetUomAsync(Guid uomId)
    {
        var request = new RestRequest(C_Uoms + "/" + uomId);
        return await Client.GetAsync<UomDto>(request);
    }

    public async Task PostUomsAsync(IEnumerable<UomDto> uoms)
    {
        var request = new RestRequest(C_Uoms);
        request.AddBody(uoms);
        await Client.PostAsync(request);
    }

    public async Task PutUomsAsync(IEnumerable<UomDto> uoms)
    {
        var request = new RestRequest(C_Uoms);
        request.AddBody(uoms);
        await Client.PutAsync(request);
    }

    public async Task DeleteUomAsync(Guid uomId)
    {
        var request = new RestRequest(C_Uoms + "/" + uomId);
        await Client.DeleteAsync(request);
    }

}
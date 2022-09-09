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

    public async Task<List<UomDto>> GetAsync()
    {
        var request = new RestRequest(C_Uoms);
        return await Client.GetAsync<List<UomDto>>(request);
    }

    public async Task<UomDto> GetAsync(Guid id)
    {
        var request = new RestRequest(C_Uoms + "/" + id);
        return await Client.GetAsync<UomDto>(request);
    }

    public async Task PostAsync(IEnumerable<UomDto> uoms)
    {
        var request = new RestRequest(C_Uoms);
        request.AddBody(uoms);
        await Client.PostAsync(request);
    }

    public async Task PutAsync(IEnumerable<UomDto> uoms)
    {
        var request = new RestRequest(C_Uoms);
        request.AddBody(uoms);
        await Client.PutAsync(request);
    }

    public async Task DeleteAsync(Guid id)
    {
        var request = new RestRequest(C_Uoms + "/" + id);
        await Client.DeleteAsync(request);
    }

}
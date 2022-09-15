using Demo.Contracts.Dtos;
using RestSharp;

namespace Demo.Contracts.RestServices;

public class SecurityClient : RestService
{
    public SecurityClient() : base()
    {
    }

    public SecurityClient(RestClient client) : base(client)
    {
    }

    private const string C_Security = "Security";

    public async Task<LoginResponseDto> LoginAsync(LoginDto login)
    {
        var request = new RestRequest(C_Security + "/Login");
        request.AddBody(login);
        return await Client.PostAsync<LoginResponseDto>(request);

    }
}
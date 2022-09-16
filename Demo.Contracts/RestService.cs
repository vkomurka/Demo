using RestSharp;

namespace Demo.Contracts;

public class RestService
{
    protected RestClient Client { get; set; }


    public RestService()
    {
        SetClient(new RestClient(RestServiceConfig.BaseUrl));
    }

    public RestService(RestClient client)
    {
        if (client == null) throw new ArgumentNullException(nameof(client));

        SetClient(client);
    }

    protected virtual void SetClient(RestClient client)
    {
        Client = client;
    }

}
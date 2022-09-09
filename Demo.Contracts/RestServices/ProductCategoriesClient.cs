using RestSharp;

namespace Demo.Contracts.RestServices;

public class ProductCategoriesClient : RestService
{
    public ProductCategoriesClient() : base()
    {
    }

    public ProductCategoriesClient(RestClient client) : base(client)
    {
    }
}
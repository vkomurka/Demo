using Demo.Contracts.Dtos;
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

    private const string C_ProductCategories = "productcategories";

    public async Task<List<ProductCategoryDto>> GetAsync()
    {
        var request = new RestRequest(C_ProductCategories);
        return await Client.GetAsync<List<ProductCategoryDto>>(request);
    }

    public async Task<ProductCategoryDto> GetAsync(Guid id)
    {
        var request = new RestRequest(C_ProductCategories + "/" + id);
        return await Client.GetAsync<ProductCategoryDto>(request);
    }

    public async Task PostAsync(IEnumerable<ProductCategoryDto> categories)
    {
        var request = new RestRequest(C_ProductCategories);
        request.AddBody(categories);
        await Client.PostAsync(request);
    }

    public async Task PutAsync(IEnumerable<ProductCategoryDto> categories)
    {
        var request = new RestRequest(C_ProductCategories);
        request.AddBody(categories);
        await Client.PutAsync(request);
    }

    public async Task DeleteAsync(Guid id)
    {
        var request = new RestRequest(C_ProductCategories + "/" + id);
        await Client.DeleteAsync(request);
    }
}
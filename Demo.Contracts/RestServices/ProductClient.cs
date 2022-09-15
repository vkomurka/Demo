using Demo.Contracts.Dtos;
using RestSharp;

namespace Demo.Contracts.RestServices
{
    public class ProductClient : RestService
    {
        public ProductClient() : base()
        {
        }

        public ProductClient(RestClient client) : base(client)
        {
        }

        private const string C_Products = "Products";

        public async Task<List<ProductDto>> GetAsync()
        {
            var request = new RestRequest(C_Products);
            return await Client.GetAsync<List<ProductDto>>(request);
        }

        public async Task<ProductDto> GetAsync(Guid id)
        {
            var request = new RestRequest(C_Products + "/" + id);
            return await Client.GetAsync<ProductDto>(request);
        }

        public async Task PostAsync(IEnumerable<ProductDto> products)
        {
            var request = new RestRequest(C_Products);
            request.AddBody(products);
            await Client.PostAsync(request);
        }

        public async Task PutAsync(IEnumerable<ProductDto> products)
        {
            var request = new RestRequest(C_Products);
            request.AddBody(products);
            await Client.PutAsync(request);
        }

        public async Task DeleteAsync(Guid id)
        {
            var request = new RestRequest(C_Products + "/" + id);
            await Client.DeleteAsync(request);
        }
    }
}

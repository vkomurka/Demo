using Demo.Contracts.Dtos;
using RestSharp;

namespace Demo.Contracts
{
    public class UomsClient
    {
        protected string BaseUrl { get; }
        protected RestClient Client { get; set; }


        public UomsClient(string baseUrl)
        {
            BaseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
            Client = new RestClient(BaseUrl);
        }

        public UomsClient(RestClient client)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
        }


        public async Task<List<UomDto>> GetUomsAsync()
        {
            var request = new RestRequest("uoms");
            return await Client.GetAsync<List<UomDto>>(request);
        }
    }
}

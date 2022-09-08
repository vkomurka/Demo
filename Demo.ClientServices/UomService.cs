using Demo.Contracts.Dtos;
using RestSharp;

namespace Demo.ClientServices
{
    public class UomService
    {
        public async Task<List<UomDto>> LoadUoms()
        {
            var client = new RestClient("https://localhost:7111/api/");
            var request = new RestRequest("uoms");
            return await client.GetAsync<List<UomDto>>(request);
        }

        public async Task AddUoms(List<UomDto> uoms)
        {
            var client = new RestClient("https://localhost:7111/api/");
            var request = new RestRequest("uoms");
            request.AddBody(uoms);
            var test = await client.PostAsync(request);
        }

        public async Task PutUoms(List<UomDto> uoms)
        {
            var client = new RestClient("https://localhost:7111/api/");
            var request = new RestRequest("uoms");
            request.AddBody(uoms);
            var test = await client.PutAsync(request);
        }

        public async Task<List<UomDto>> FindUom(Guid uomId)
        {
            var client = new RestClient("https://localhost:7111/api/");
            var request = new RestRequest("uoms/" + uomId);
            return await client.GetAsync<List<UomDto>>(request);
        }

        public async Task DeleteUom(Guid uomId)
        {
            var client = new RestClient("https://localhost:7111/api/");
            var request = new RestRequest("uoms/" + uomId);
            await client.DeleteAsync(request);
        }
    }
}

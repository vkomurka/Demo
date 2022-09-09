using Demo.Contracts.Dtos;
using RestSharp;

namespace Demo.Contracts.RestServices
{
    public class WarehousesClient : RestService
    {
        public WarehousesClient() : base()
        {
        }

        public WarehousesClient(RestClient client) : base(client)
        {
        }

        private const string C_Warehouses = "warehouses";

        public async Task<List<WarehouseDto>> GetAsync()
        {
            var request = new RestRequest(C_Warehouses);
            return await Client.GetAsync<List<WarehouseDto>>(request);
        }

        public async Task<WarehouseDto> GetAsync(Guid id)
        {
            var request = new RestRequest(C_Warehouses + "/" + id);
            return await Client.GetAsync<WarehouseDto>(request);
        }

        public async Task PostAsync(IEnumerable<WarehouseDto> warehouses)
        {
            var request = new RestRequest(C_Warehouses);
            request.AddBody(warehouses);
            await Client.PostAsync(request);
        }

        public async Task PutAsync(IEnumerable<WarehouseDto> warehouses)
        {
            var request = new RestRequest(C_Warehouses);
            request.AddBody(warehouses);
            await Client.PutAsync(request);
        }

        public async Task DeleteAsync(Guid id)
        {
            var request = new RestRequest(C_Warehouses + "/" + id);
            await Client.DeleteAsync(request);
        }
    }
}

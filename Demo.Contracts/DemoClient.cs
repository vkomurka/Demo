using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Contracts.Dtos;
using RestSharp;

namespace Demo.Contracts
{
    public class DemoClient
    {
        protected string BaseUrl { get; }
        protected RestClient Client { get; set; }


        public DemoClient(string baseUrl)
        {
            BaseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
            Client = new RestClient(BaseUrl);

            Uoms = new UomsClient(Client);
        }

        public UomsClient Uoms { get; set; }

    }
}

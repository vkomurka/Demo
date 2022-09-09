using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}

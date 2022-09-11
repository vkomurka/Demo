﻿using Demo.Contracts.RestServices;
using RestSharp;

namespace Demo.Contracts;

public class DemoClient : RestService
{
    public DemoClient() : base()
    {
    }

    public DemoClient(RestClient client) : base(client)
    {
    }


    public ProductClient Products { get; set; }
    public ProductCategoriesClient ProductCategories { get; set; }
    public UomsClient Uoms { get; set; }
    public WarehousesClient Warehouses { get; set; }


    protected override void SetClient(RestClient client)
    {
        base.SetClient(client);

        Products = new ProductClient();
        ProductCategories = new ProductCategoriesClient(client);
        Uoms = new UomsClient(client);
        Warehouses = new WarehousesClient(client);
    }
}
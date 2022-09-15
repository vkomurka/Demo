using Demo.Contracts.Dtos;
using RestSharp;
using RestSharp.Authenticators;

var client = new RestClient("https://localhost:7111/api/");

var request = new RestRequest("Account/Login");
request.AddBody(new LoginDto { Email = "admin@admin.com", Password = "Admin*123" });
var response = await client.PostAsync<LoginResponseDto>(request);

Console.WriteLine(response.Token);

client.Authenticator = new JwtAuthenticator(response.Token);

var requestPostUom = new RestRequest("Uoms");
requestPostUom.AddBody(new List<UomDto>() { new() { Id = Guid.NewGuid(), Code = "kg" } });
var responsePostUom = client.PostAsync(requestPostUom);

var requestUoms = new RestRequest("Uoms");
var responseUoms = await client.GetAsync<List<UomDto>>(requestUoms);

foreach (var responseUom in responseUoms)
{
    Console.WriteLine(responseUom.Code);
}

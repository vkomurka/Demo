using Demo.Desktop.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
var connectionString = configuration.GetConnectionString("Context");

//var context = new Context(connectionString);
//context.Database.Migrate();

using Demo.DAL;

namespace Demo.WebServer.Model.Entities;

public class Warehouse : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}


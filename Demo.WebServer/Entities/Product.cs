using Demo.Entities;

namespace Demo.WebServer.Entities;

public class Product : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid UomId { get; set; }
    public Guid? ProductCategoryId { get; set; }
}


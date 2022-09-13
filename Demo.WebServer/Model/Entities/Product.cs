using Demo.DAL;

namespace Demo.WebServer.Model.Entities;

public class Product : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid UomId { get; set; }
    public Guid? ProductCategoryId { get; set; }
}


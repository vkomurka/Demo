using Demo.DAL;

namespace Demo.WebServer.Entities;

public class Inventory : IEntity
{
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }
    public Guid UomId { get; set; }
    public decimal Quantity { get; set; }
}

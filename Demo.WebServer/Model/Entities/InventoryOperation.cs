using Demo.DAL;

namespace Demo.WebServer.Model.Entities;

public class InventoryOperation : IEntity
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
}

using Demo.DAL;

namespace Demo.Desktop.Model.Entities;

public class Setting : IEntity
{
    public Guid Id { get; set; }
    public string  DemoServerBaseUrl { get; set; }

}
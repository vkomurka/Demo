namespace Demo.Contracts.Dtos;

public class ProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Guid? UomId { get; set; }
    public Guid? ProductCategoryId { get; set; }

    public string UomCode { get; set; }
    public string ProductCategoryName { get; set; }
}

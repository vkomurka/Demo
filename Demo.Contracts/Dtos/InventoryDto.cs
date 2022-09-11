namespace Demo.Contracts.Dtos
{
    public class InventoryDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid UomId { get; set; }
        public decimal Quantity { get; set; }
        public string ProductName { get; set; }
        public Guid? ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
        public string UomCode { get; set; }
    }
}

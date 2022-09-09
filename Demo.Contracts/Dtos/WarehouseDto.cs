using System.ComponentModel.DataAnnotations;

namespace Demo.Contracts.Dtos
{
    public class WarehouseDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}

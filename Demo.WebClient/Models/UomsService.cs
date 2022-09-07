using Demo.Contracts.Dtos;

namespace Demo.WebClient.Models
{
    public static class UomsService
    {
        public static List<UomDto> Uoms { get; set; } = new()
        {
            new UomDto() { Id = Guid.NewGuid(), Code = "kg" },
            new UomDto() { Id = Guid.NewGuid(), Code = "pcs" },
        };
    }
}

using System.ComponentModel.DataAnnotations;

namespace Demo.Contracts.Dtos;

public class UomDto
{
    public Guid Id { get; set; }
    [Required]
    public string Code { get; set; }
}

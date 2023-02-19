using System.ComponentModel.DataAnnotations;

namespace CoreBusiness;

public class Product
{
    public int ProductId { get; set; }
    [Required]
    public int? CategoryId { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    [Required]
    public double? Price { get; set; }
    [Required]
    public int? Quantity { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace CoreBusiness;

public class Transaction
{
    public int TransactionId { get; set; }
    [Required]
    public DateTime Timestamp { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty; // In case product name changes
    public double Price { get; set; }
    public int BeforeQuantity { get; set; }
    public int SoldQuantity { get; set; }
    public string CashierName { get; set; } = string.Empty;
}
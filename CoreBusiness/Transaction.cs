using System.ComponentModel.DataAnnotations;

namespace CoreBusiness;

public class Transaction
{
    public int TransactionId { get; set; }
    [Required]
    public DateTime Timestamp { get; set; }
    public int ProductId { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public string CashierName { get; set; } = string.Empty;
}
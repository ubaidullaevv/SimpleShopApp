namespace Domain.Models;


public class Order
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public DateOnly OrderDate { get; set; }
}
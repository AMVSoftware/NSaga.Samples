using System;
using NSaga;

public class AddProductIntoBasket : ISagaMessage
{
    public Guid CorrelationId { get; set; }

    public int ProductId { get; set; }
    public String ProductName { get; set; }
    public int ItemCount { get; set; }
    public decimal ItemPrice { get; set; }
}
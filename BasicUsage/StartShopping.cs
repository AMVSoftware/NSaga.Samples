using System;
using NSaga;

public class StartShopping : IInitiatingSagaMessage
{
    public Guid CorrelationId { get; set; }
    public Guid CustomerId { get; set; }
}
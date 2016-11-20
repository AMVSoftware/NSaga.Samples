using System;
using NSaga;

namespace BasicUsage
{
    public class NotifyCustomerAboutBasket : ISagaMessage
    {
        public Guid CorrelationId { get; set; }
    }
}

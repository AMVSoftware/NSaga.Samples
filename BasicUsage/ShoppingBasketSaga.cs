using System;
using System.Collections.Generic;
using BasicUsage;
using NSaga;


public class ShoppingBasketData
{
    public Guid CustomerId { get; set; }
    public List<BasketProducts> BasketProducts { get; set; }
    public bool BasketCheckedout { get; set; }

    public ShoppingBasketData()
    {
        BasketProducts = new List<BasketProducts>();
    }
}


public class ShoppingBasketSaga : ISaga<ShoppingBasketData>,
    InitiatedBy<StartShopping>,
    ConsumerOf<AddProductIntoBasket>,
    ConsumerOf<NotifyCustomerAboutBasket>
{
    public Guid CorrelationId { get; set; }
    public Dictionary<string, string> Headers { get; set; }
    public ShoppingBasketData SagaData { get; set; }

    private readonly IEmailService emailService;
    private readonly ICustomerRepository customerRepository;

    public ShoppingBasketSaga(IEmailService emailService, ICustomerRepository customerRepository)
    {
        this.emailService = emailService;
        this.customerRepository = customerRepository;
        Headers = new Dictionary<string, string>();
        SagaData = new ShoppingBasketData();
    }


    public OperationResult Initiate(StartShopping message)
    {
        SagaData.CustomerId = message.CustomerId;
        Console.WriteLine("Starting Shopping Saga");
        return new OperationResult(); // no errors to report
    }


    public OperationResult Consume(AddProductIntoBasket message)
    {
        SagaData.BasketProducts.Add(new BasketProducts()
        {
            ProductId = message.ProductId,
            ProductName = message.ProductName,
            ItemCount = message.ItemCount,
            ItemPrice = message.ItemPrice,
        });
        Console.WriteLine("Adding a product into shopping basket");
        return new OperationResult(); // no possibility to fail
    }


    public OperationResult Consume(NotifyCustomerAboutBasket message)
    {
        Console.WriteLine("Trying to send notification email");

        var customer = customerRepository.Find(SagaData.CustomerId);
        if (String.IsNullOrEmpty(customer.Email))
        {
            return new OperationResult("No email recorded for the customer - unable to send message");
        }

        try
        {
            var emailMessage = $"We see your basket is not checked-out. We offer you a 85% discount if you go ahead with the checkout. Please visit https://www.example.com/ShoppingBasket/{CorrelationId}";
            emailService.SendEmail(customer.Email, "Checkout not complete", emailMessage);
        }
        catch (Exception exception)
        {
            return new OperationResult($"Failed to send email: {exception}");
        }
        return new OperationResult(); // operation successful
    }
}
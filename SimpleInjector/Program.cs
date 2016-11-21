using System;
using BasicUsage;
using NSaga;
using NSaga.SimpleInjector;
using Sagas.ShoppingBasket;
using SimpleInjector;

class Program
{
    static void Main(string[] args)
    {
        var container = new Container();

        container.RegisterNSagaComponents()
            .UseSqlServer()
            .WithConnectionString(@"Data Source=.\SQLEXPRESS;integrated security=SSPI;Initial Catalog=NSaga");

        container.Register<IEmailService, ConsoleEmailService>();
        container.Register<ICustomerRepository, SimpleCustomerRepository>();

        var mediator = container.GetInstance<ISagaMediator>();
        var repository = container.GetInstance<ISagaRepository>();

        var correlationId = Guid.NewGuid();

        // start the shopping.
        mediator.Consume(new StartShopping()
        {
            CorrelationId = correlationId,
            CustomerId = Guid.NewGuid(),
        });

        // add a product into the basket
        mediator.Consume(new AddProductIntoBasket()
        {
            CorrelationId = correlationId,
            ProductId = 1,
            ProductName = "Magic Dust",
            ItemCount = 42,
            ItemPrice = 42.42M,
        });

        // retrieve the saga from the storage
        var saga = repository.Find<ShoppingBasketSaga>(correlationId);

        // you can access saga data this way
        if (saga.SagaData.BasketCheckedout)
        {
            // and issue another message
            mediator.Consume(new NotifyCustomerAboutBasket() { CorrelationId = correlationId });
        }

        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
    }
}
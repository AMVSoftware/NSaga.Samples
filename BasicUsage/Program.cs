using System;
using BasicUsage;
using NSaga;

class Program
{
    static void Main(string[] args)
    {
        var builder = Wireup.UseInternalContainer()
                            .UseSqlServer()
                            .WithConnectionStringName("NSagaDatabase");

        // register dependencies for sagas
        builder.Register(typeof(IEmailService), typeof(ConsoleEmailService));
        builder.Register(typeof(ICustomerRepository), typeof(SimpleCustomerRepository));

        var mediator = builder.ResolveMediator(); 

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
        var repository = builder.ResolveRepository();
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
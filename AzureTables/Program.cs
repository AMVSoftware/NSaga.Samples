using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicUsage;
using NSaga;
using NSaga.AzureTables;
using Sagas.ShoppingBasket;

namespace AzureTables
{
    public class Program
    {
        static void Main(string[] args)
        {
            // You need Azure Storage emulator running to run this
            var connectionString = "UseDevelopmentStorage=true";
            var builder = Wireup.UseInternalContainer()
                                .AddAssemblyToScan(typeof(ShoppingBasketSaga).Assembly)
                                .UseRepository<AzureTablesSagaRepository>()
                                .Register(typeof(ITableClientFactory), new TableClientFactory(connectionString));

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
}

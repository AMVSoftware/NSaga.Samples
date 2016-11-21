using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using BasicUsage;
using NSaga;
using NSaga.Autofac;
using Sagas.ShoppingBasket;

namespace AutofacSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterNSagaComponents()
                .UseSqlServer()
                .WithConnectionString(@"Data Source=.\SQLEXPRESS;integrated security=SSPI;Initial Catalog=NSaga");

            containerBuilder.RegisterType<ConsoleEmailService>().As<IEmailService>();
            containerBuilder.RegisterType<SimpleCustomerRepository>().As<ICustomerRepository>();

            var container = containerBuilder.Build();

            var mediator = container.Resolve<ISagaMediator>();
            var repository = container.Resolve<ISagaRepository>();

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
}

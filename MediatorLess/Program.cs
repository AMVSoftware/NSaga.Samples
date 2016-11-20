using System;
using System.Collections.Generic;
using NSaga;

namespace MediatorLess
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = Wireup.UseInternalContainer();
            var repository = builder.ResolveRepository();

            var correlationId = Guid.NewGuid();

            var simpleSaga = new VerySimpleSaga()
            {
                CorrelationId = correlationId,
                SagaData = new DataStorage(),
                Headers = new Dictionary<string, string>(),
            };

            repository.Save(simpleSaga); // initiate

            var result = simpleSaga.Consume(new SimpleMessage() {CorrelationId = correlationId, Value = "blah"});
            if (result.IsSuccessful)
            {
                repository.Save(simpleSaga);
            }

            Console.ReadKey();
        }
    }
}

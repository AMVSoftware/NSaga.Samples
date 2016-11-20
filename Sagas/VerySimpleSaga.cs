using System;
using System.Collections.Generic;
using NSaga;


public class DataStorage
{
    public String Name { get; set; }
    public String Value { get; set; }
}

public class VerySimpleSaga : ISaga<DataStorage>, 
                              InitiatedBy<SimpleStartMessage>, 
                              ConsumerOf<SimpleMessage>
{
    public Guid CorrelationId { get; set; }
    public Dictionary<string, string> Headers { get; set; }
    public DataStorage SagaData { get; set; }


    public OperationResult Initiate(SimpleStartMessage message)
    {
        SagaData.Name = message.Name;
        Console.WriteLine($"Name is {SagaData.Name}");
        return new OperationResult();
    }


    public OperationResult Consume(SimpleMessage message)
    {
        SagaData.Value = message.Value;
        Console.WriteLine($"Value is {SagaData.Value}");
        return new OperationResult();
    }
}

public class SimpleStartMessage : IInitiatingSagaMessage
{
    public Guid CorrelationId { get; set; }

    public String Name { get; set; }
}

public class SimpleMessage : ISagaMessage
{
    public Guid CorrelationId { get; set; }

    public String Value { get; set; }
}
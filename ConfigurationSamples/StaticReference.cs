using ConfigurationSamples;
using NSaga;


class StaticReference
{
    public StaticReference()
    {
        var builder = Wireup.UseInternalContainer()
                           .UseRepository<DummySagaRepository>()
                           .UseMessageSerialiser<DummyMessageSerialiser>()
                           .UseSagaFactory<DummySagaFactory>();

        SagaMediatorBuilder.Current = builder;

        var sagaMediator = SagaMediatorBuilder.Current.ResolveMediator();
    }
}

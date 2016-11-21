using System;
using NSaga;

namespace ConfigurationSamples
{
    class DummySagaFactory : ISagaFactory
    {
        public T ResolveSaga<T>() where T : class, IAccessibleSaga
        {
            return Activator.CreateInstance<T>();
        }

        public IAccessibleSaga ResolveSaga(Type type)
        {
            return (IAccessibleSaga)Activator.CreateInstance(type);
        }

        public IAccessibleSaga ResolveSagaInititatedBy(IInitiatingSagaMessage message)
        {
            throw new NotImplementedException();
        }

        public IAccessibleSaga ResolveSagaConsumedBy(ISagaMessage message)
        {
            throw new NotImplementedException();
        }
    }
}

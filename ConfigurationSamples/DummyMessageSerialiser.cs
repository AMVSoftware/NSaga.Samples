using System;
using NSaga;

namespace ConfigurationSamples
{
    class DummyMessageSerialiser : IMessageSerialiser
    {
        public string Serialise(object message)
        {
            return String.Empty;
        }

        public object Deserialise(string stream, Type objectType)
        {
            return new object();
        }

        public T Deserialise<T>(string stream)
        {
            return default(T);
        }
    }
}

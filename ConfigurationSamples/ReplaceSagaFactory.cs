using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSaga;

namespace ConfigurationSamples
{
    class ReplaceSagaFactory
    {
        public ReplaceSagaFactory()
        {
            var builder = Wireup.UseInternalContainer()
                                .UseSagaFactory<DummySagaFactory>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSaga;

namespace ConfigurationSamples
{
    class ReplaceMessageSerialiser
    {
        public ReplaceMessageSerialiser()
        {
            var builder = Wireup.UseInternalContainer()
                                .UseMessageSerialiser<DummyMessageSerialiser>();
        }
    }
}

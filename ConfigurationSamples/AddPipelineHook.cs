using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSaga;

namespace ConfigurationSamples
{
    class AddPipelineHook
    {
        public AddPipelineHook()
        {
            var builder = Wireup.UseInternalContainer()
                                .AddPiplineHook<DummyPipelineHook>();
        }
    }
}

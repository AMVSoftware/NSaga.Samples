using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSaga;

namespace ConfigurationSamples
{
    class ReplaceRepository
    {
        public ReplaceRepository()
        {
            var builder = Wireup.UseInternalContainer()
                                .UseRepository<DummySagaRepository>();
        }
    }
}

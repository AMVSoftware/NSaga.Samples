using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSaga;

namespace ConfigurationSamples
{
    class DummySagaRepository : ISagaRepository
    {
        public TSaga Find<TSaga>(Guid correlationId) where TSaga : class, IAccessibleSaga
        {
            return default(TSaga);
        }

        public void Save<TSaga>(TSaga saga) where TSaga : class, IAccessibleSaga
        {
            // nothing
        }

        public void Complete<TSaga>(TSaga saga) where TSaga : class, IAccessibleSaga
        {
            // nothing
        }

        public void Complete(Guid correlationId)
        {
            // nothing
        }
    }
}

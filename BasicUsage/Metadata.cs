using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSaga;

namespace BasicUsage
{
    public class Metadata
    {
        public Metadata()
        {
            var messageSerialiser = Wireup.UseInternalContainer().Resolve<IMessageSerialiser>();

            var simpleSaga = new VerySimpleSaga();
            var metadata = simpleSaga.GetSagaMetadata(messageSerialiser);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSaga;

namespace ConfigurationSamples
{
    class DummyPipelineHook : IPipelineHook
    {
        public void BeforeInitialisation(PipelineContext context)
        {
        }

        public void AfterInitialisation(PipelineContext context)
        {
        }

        public void BeforeConsuming(PipelineContext context)
        {
        }

        public void AfterConsuming(PipelineContext context)
        {
        }

        public void AfterSave(PipelineContext context)
        {
        }
    }
}

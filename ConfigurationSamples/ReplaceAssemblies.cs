using System.Reflection;
using NSaga;

namespace ConfigurationSamples
{
    class ReplaceAssemblies
    {
        public ReplaceAssemblies()
        {
            var builder = Wireup.UseInternalContainer()
                                .ReplaceAssembliesToScan(new Assembly[] { typeof(ReplaceAssemblies).Assembly })
                                .AddAssembliesToScan(new Assembly[] {typeof(VerySimpleSaga).Assembly});
        }
    }
}

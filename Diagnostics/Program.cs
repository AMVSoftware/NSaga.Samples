using System;
using NSaga;

namespace Diagnostics
{
    class Program
    {
        static void Main(string[] args)
        {
            var validator = new NSagaConfigurationValidator(new[] { typeof(VerySimpleSaga).Assembly });

            validator.AssertConfigurationIsValid(); // exceptions should be thrown in case of errors

            Console.WriteLine("Validation is complete");
            Console.ReadKey();
        }
    }
}

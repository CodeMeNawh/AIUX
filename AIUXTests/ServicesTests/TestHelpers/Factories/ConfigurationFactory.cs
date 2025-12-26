using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIUXTests.ServicesTests.TestHelpers.Factories
{
    internal static class ConfigurationFactory
    {
        internal static IConfiguration Create()
        {
            return new ConfigurationBuilder().AddInMemoryCollection(
                new Dictionary<string, string?>
                {
                    { "Jwt:Key", "TEST_SECRET_KEY_1234567890" }
                }).Build();

            
        }
    }
}

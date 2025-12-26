using AIUX.Models;
using AIUX.Services;
using AIUXTests.ServicesTests.TestHelpers.Seeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIUXTests.ServicesTests.TestHelpers.Factories
{
    internal static class UserServiceFactory
    {
        internal static async Task<(UserService service, User seededUser)>CreateServiceWithUserAsync(
            string email = "mat@onet.pl", string password = "Password123")
        {
            var context = DbContextFactory.Create();
            var seededUser = await UserSeeder.SeedUserAsync(context, email, password);
            var config = ConfigurationFactory.Create();
            var service = new UserService(context, config);
            return (service, seededUser);
        }
    }
}

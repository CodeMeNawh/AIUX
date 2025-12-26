using AIUX.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIUXTests.ServicesTests.TestHelpers.Factories
{
    internal static class DbContextFactory
    {
        internal static AppDbContext Create()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().
                UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            return new AppDbContext(options);
        }
    }
}

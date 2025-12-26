using AIUX.Data;
using AIUX.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIUXTests.ServicesTests.TestHelpers.Seeders
{
    internal static class UserSeeder
    {
        internal static async Task<User>SeedUserAsync
            (AppDbContext context, string email , string password )
        {
            var user = new User
            {
                Email = email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password)
            };

            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user;

        }
    }
}


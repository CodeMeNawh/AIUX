using AIUX.Services;
using AIUXTests.ServicesTests.TestHelpers.Factories;
using AIUXTests.ServicesTests.TestHelpers.Seeders;
using NUnit.Framework;
using System.Threading.Tasks;


namespace AIUXTests.ServicesTests.Users
{
    
    public class UserServiceTests
    {
        [Test]
        public async Task IsTakenEmailAsync_ReturnsTrue_WhenEmailExists() 
        {
            //Arrange
            var (service, user) = await UserServiceFactory.CreateServiceWithUserAsync();
            //Act
            var result = await service.IsTakenEmailAsync(user.Email);
            //Assert
            Assert.True(result);
        }

        [Test]
        public async Task IsTakenEmailAsync_ReturnsFalse_WhenEmailNotExists()
        {
            //Arrange
            var (service, _) = await UserServiceFactory.CreateServiceWithUserAsync();
            //Act
            var result = await service.IsTakenEmailAsync("nonexistent@test.com");
            //Assert
            Assert.That(result, Is.False);
        }

    }
}

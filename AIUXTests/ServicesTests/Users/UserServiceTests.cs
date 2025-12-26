using AIUX.Services;
using AIUXTests.ServicesTests.TestHelpers.Factories;
using AIUXTests.ServicesTests.TestHelpers.Seeders;
using NUnit.Framework;
using System.Threading.Tasks;


namespace AIUXTests.ServicesTests.Users
{
    
    public class UserServiceTests
    {

        [TestCase("mat@onet.pl", true)]
        [TestCase("nonexistent@test.com", false)]
        public async Task IsTakenEmailAsync_ExpectedResult(string expectedEmail, bool expected)
        {
            //Arrange
            var (service, _) = await UserServiceFactory.CreateServiceWithUserAsync();
            //Act
            var result = await service.IsTakenEmailAsync(expectedEmail);
            //Assert

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}

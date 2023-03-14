using Data.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Services;
using Xunit.Abstractions;

namespace Test.Integration
{
    [Collection("IntegrationTests")]
    public class IntegrationTest : IDisposable
    {
        private readonly DbContextOptions<ApiRestDbManuelRojasContext> _options;
        private readonly ApiRestDbManuelRojasContext _dbContext;
        private readonly ITestOutputHelper _output;

        public IntegrationTest(ITestOutputHelper output)
        {
            _output = output;
            _options = new DbContextOptionsBuilder<ApiRestDbManuelRojasContext>()
                .UseSqlServer("Server=ASUS_TUF_MR\\SQLEXPRESS; Database=ApiRestDB_ManuelRojas; Trusted_Connection=True; Encrypt=False;")
                .Options;
            _dbContext = new ApiRestDbManuelRojasContext(_options);
        }

        [Fact]
        public void AccountRepositoryService()
        {
            // Arrange
            var service = new AccountRepositoryService(_dbContext);

            // Act
            var result = service.GetAll();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void ClientRepositoryService()
        {
            // Arrange
            var service = new ClientRepositoryService(_dbContext);

            // Act
            var result = service.GetAll();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void MovementRepositoryService()
        {
            // Arrange
            var service = new MovementRepositoryService(_dbContext);

            // Act
            var result = service.GetAll();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void PersonRepositoryService()
        {
            // Arrange
            var service = new PersonRepositoryService(_dbContext);

            // Act
            var result = service.GetAll();

            // Assert
            Assert.NotNull(result);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
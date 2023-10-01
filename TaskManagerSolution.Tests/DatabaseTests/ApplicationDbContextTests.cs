using Microsoft.EntityFrameworkCore;
using TaskManagerSolution.Server.Data;
using TaskManagerSolution.Shared.Models;
using Xunit;

namespace TaskManagerSolution.Tests.DatabaseTests
{
    public class ApplicationDbContextTests
    {
        private DbContextOptions<ApplicationDbContext> _options;

        public ApplicationDbContextTests()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;
        }

        [Fact]
        public async Task CanAddUser()
        {
            // Arrange
            var user = new User { Username = "testUser", Email = "test@email.com" };

            // Act
            using (var context = new ApplicationDbContext(_options))
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();
            }

            // Assert
            using (var context = new ApplicationDbContext(_options))
            {
                Assert.Single(context.Users);
                var firstUser = await context.Users.FirstAsync();
                Assert.Equal("testUser", firstUser.Username);
            }
        }
    }
}

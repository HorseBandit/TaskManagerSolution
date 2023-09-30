using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerSolution.Shared.Models;
using Xunit;

namespace TaskManagerSolution.Tests.ModelTests
{
    public class UserTests
    {
        [Fact]
        public void CanChangeUserUsername()
        {
            // Arrange
            var user = new User { Username = "Test" };

            // Act
            user.Username = "Changed";

            // Assert
            Assert.Equal("Changed", user.Username);
        }
    }
}

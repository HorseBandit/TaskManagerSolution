using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerSolution.Shared.Models;
using Xunit;

namespace TaskManagerSolution.Tests.ModelTests
{
    public class SquadTests
    {
        [Fact]
        public void CanChangeSquadName()
        {
            // Arrange
            var squad = new Squad { Name = "Test" };

            // Act
            squad.Name = "Changed";

            // Assert
            Assert.Equal("Changed", squad.Name);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerSolution.Shared.Models;
using Xunit;

namespace TaskManagerSolution.Tests.ModelTests
{
    public class TaskToDoTests
    {
        [Fact]
        public void CanChangeTaskToDoTitle()
        {
            // Arrange
            var task = new TaskToDo { Title = "Test" };

            // Act
            task.Title = "Changed";

            // Assert
            Assert.Equal("Changed", task.Title);
        }
    }
}


using System;
using Mimic.Domain.Experiments.Configuration;
using FluentAssertions;
using Xunit;

namespace Mimic.DomainUnitTests.Experiments.Configuration;

public class TasksToCompleteTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(100)]
    public void Constructor_AllowsTasksToCompleteOfZeroOrHigher(int tasks)
    {
        var action = () => new TasksToComplete(tasks);
        action.Should().NotThrow();
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-100)]
    public void Constructor_ThrowsAnArgumentException_WhenInvokedWithTasksToCompleteLessThanZero(int tasks)
    {
        var action = () => new TasksToComplete(tasks);
        action.Should().ThrowExactly<ArgumentException>();
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(100)]
    public void ValueReturnsTheTasksToComplete(int expected)
    {
        var tasksToComplete = new TasksToComplete(expected);
        tasksToComplete.Value().Should().Be(expected);
    }
}

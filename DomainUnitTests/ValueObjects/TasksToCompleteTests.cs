using System;
using Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace DomainUnitTests.ValueObjects;

public class TasksToCompleteTests
{
    [Fact]
    public void DoesNotThrowAnExceptionWhenPassedAValidNumber()
    {
        Action action = () => new TasksToComplete(1);
        action.Should().NotThrow();
    }

    [Fact]
    public void ThrowsAnArgumentExceptionWhenPassedAnInvalidNumber()
    {
        Action action = () => new TasksToComplete(-1);
        action.Should().ThrowExactly<ArgumentException>();
    }

    [Fact]
    public void ValueReturnsTheExpectedResult()
    {
        const int expectedTasksToComplete = 5;
        var tasksToComplete = new TasksToComplete(expectedTasksToComplete);
        tasksToComplete.Value().Should().Be(expectedTasksToComplete);
    }
}

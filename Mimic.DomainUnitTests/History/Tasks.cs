using System;
using FluentAssertions;
using Mimic.Domain.History;
using Xunit;

namespace Mimic.DomainUnitTests.History;

public class TasksTest
{
    [Fact]
    public void DoesNotThrowAnExceptionWhenPassedAValidNumber()
    {
        var action = () => new Tasks(0);
        action.Should().NotThrow();
    }

    [Fact]
    public void ThrowsAnArgumentExceptionWhenPassedAnInvalidNumber()
    {
        var action = () => new Tasks(-1);
        action.Should().ThrowExactly<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void ValueReturnsTheExpectedResult()
    {
        const int expectedCompletedTasks = 5;
        var record = new Tasks(expectedCompletedTasks);
        record.Value().Should().Be(expectedCompletedTasks);
    }
}

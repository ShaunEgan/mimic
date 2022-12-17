using System;
using Domain.Tasks;
using FluentAssertions;
using Xunit;

namespace DomainUnitTests.Tasks;

public class RecordTest
{
    [Fact]
    public void DoesNotThrowAnExceptionWhenPassedAValidNumber()
    {
        var action = () => new CompletedTasks(0);
        action.Should().NotThrow();
    }

    [Fact]
    public void ThrowsAnArgumentExceptionWhenPassedAnInvalidNumber()
    {
        var action = () => new CompletedTasks(-1);
        action.Should().ThrowExactly<ArgumentException>();
    }

    [Fact]
    public void ValueReturnsTheExpectedResult()
    {
        const int expectedCompletedTasks = 5;
        var record = new CompletedTasks(expectedCompletedTasks);
        record.Value().Should().Be(expectedCompletedTasks);
    }
}

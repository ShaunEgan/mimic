using System;
using Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace DomainUnitTests.ValueObjects;

public class RecordTest
{
    [Fact]
    public void DoesNotThrowAnExceptionWhenPassedAValidNumber()
    {
        Action action = () => new CompletedTasks(0);
        action.Should().NotThrow();
    }

    [Fact]
    public void ThrowsAnArgumentExceptionWhenPassedAnInvalidNumber()
    {
        Action action = () => new CompletedTasks(-1);
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

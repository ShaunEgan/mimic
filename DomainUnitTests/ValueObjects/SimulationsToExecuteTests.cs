using System;
using Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace DomainUnitTests.ValueObjects;

public class SimulationsToExecuteTests
{
    [Fact]
    public void DoesNotThrowAnExceptionWhenPassedAValidNumber()
    {
        Action action = () => new SimulationsToExecute(1);
        action.Should().NotThrow();
    }

    [Fact]
    public void ThrowsAnArgumentExceptionWhenPassedAnInvalidNumber()
    {
        Action action = () => new SimulationsToExecute(0);
        action.Should().ThrowExactly<ArgumentException>();
    }

    [Fact]
    public void ValueReturnsTheExpectedResult()
    {
        const int expectedSimulationsToExecute = 5;
        var iterationSpecification = new SimulationsToExecute(expectedSimulationsToExecute);
        iterationSpecification.Value().Should().Be(expectedSimulationsToExecute);
    }
}

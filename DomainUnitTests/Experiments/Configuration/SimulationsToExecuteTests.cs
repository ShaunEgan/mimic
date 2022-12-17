using System;
using Domain.Experiments.Configuration;
using FluentAssertions;
using Xunit;

namespace DomainUnitTests.Experiments.Configuration;

public class SimulationsToExecuteTests
{
    [Fact]
    public void Constructor_DefaultsToTenThousandSimulations_WhenInvokedWithoutTheSimulationsToExecuteSpecified()
    {
        var simulationsToExecute = new SimulationsToExecute();
        simulationsToExecute.Value().Should().Be(10000);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(1000)]
    public void Constructor_AllowsSimulationsOfOneOrGreater(int simulations)
    {
        var action = () => new SimulationsToExecute(simulations);
        action.Should().NotThrow();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Constructor_ThrowsAnArgumentException_WhenInvokedWithSimulationsLessThanOne(int simulations)
    {
        var action = () => new SimulationsToExecute(simulations);
        action.Should().ThrowExactly<ArgumentException>();
    }

    [Theory]
    [InlineData(1)]
    [InlineData(1000)]
    public void Value_ReturnsTheNumberOfSimulationsToExecuteProvided(int expected)
    {
        var simulationsToExecute = new SimulationsToExecute(expected);
        simulationsToExecute.Value().Should().Be(expected);
    }
}

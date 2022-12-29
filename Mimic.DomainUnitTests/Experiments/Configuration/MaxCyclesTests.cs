using System;
using Mimic.Domain.Experiments.Configuration;
using FluentAssertions;
using Xunit;

namespace Mimic.DomainUnitTests.Experiments.Configuration;

public class MaxCyclesTests
{
    [Fact]
    public void Constructor_DefaultsToOneThousandCycles_WhenInvokedWithoutTheCyclesSpecified()
    {
        var maxCycles = new MaxCycles();
        maxCycles.Value().Should().Be(1000);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    public void Constructor_AllowsCyclesOfOneOrGreater(int cycles)
    {
        var action = () => new MaxCycles(cycles);
        action.Should().NotThrow();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Constructor_ThrowsAnArgumentException_WhenInvokedWithCyclesOfLessThanOne(int cycles)
    {
        var action = () => new MaxCycles(cycles);
        action.Should().ThrowExactly<ArgumentException>();
    }

    [Theory]
    [InlineData(1)]
    [InlineData(1000)]
    public void Value_ReturnsTheNumberOfCyclesProvided(int expected)
    {
        var maxCycles = new MaxCycles(expected);
        maxCycles.Value().Should().Be(expected);
    }
}

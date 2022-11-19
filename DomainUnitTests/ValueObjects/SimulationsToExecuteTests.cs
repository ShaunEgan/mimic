using System;
using Domain.ValueObjects;
using FluentAssertions;
using NUnit.Framework;

namespace DomainUnitTests.ValueObjects
{
    public class SimulationsToExecuteTests
    {
        [Test]
        public void DoesNotThrowAnExceptionWhenPassedAValidNumber()
        {
            Action action = () => new SimulationsToExecute(1);
            action.Should().NotThrow();
        }

        [Test]
        public void ThrowsAnArgumentExceptionWhenPassedAnInvalidNumber()
        {
            Action action = () => new SimulationsToExecute(0);
            action.Should().ThrowExactly<ArgumentException>();
        }

        [Test]
        public void ValueReturnsTheExpectedResult()
        {
            const int expectedSimulationsToExecute = 5;
            var iterationSpecification = new SimulationsToExecute(expectedSimulationsToExecute);
            iterationSpecification.Value().Should().Be(expectedSimulationsToExecute);
        }
    }
}

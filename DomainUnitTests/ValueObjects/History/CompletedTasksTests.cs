using System;
using Domain.ValueObjects;
using FluentAssertions;
using NUnit.Framework;

namespace DomainUnitTests.ValueObjects.History
{
    public class RecordTest
    {
        [Test]
        public void DoesNotThrowAnExceptionWhenPassedAValidNumber()
        {
            Action action = () => new CompletedTasks(0);
            action.Should().NotThrow();
        }

        [Test]
        public void ThrowsAnArgumentExceptionWhenPassedAnInvalidNumber()
        {
            Action action = () => new CompletedTasks(-1);
            action.Should().ThrowExactly<ArgumentException>();
        }

        [Test]
        public void ValueReturnsTheExpectedResult()
        {
            const int expectedCompletedTasks = 5;
            var record = new CompletedTasks(expectedCompletedTasks);
            record.Value().Should().Be(expectedCompletedTasks);
        }
    }
}

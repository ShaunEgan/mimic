using System;
using Domain.ValueObjects;
using FluentAssertions;
using NUnit.Framework;

namespace DomainUnitTests.ValueObjects
{
    public class TasksToCompleteTests
    {
        [Test]
        public void DoesNotThrowAnExceptionWhenPassedAValidNumber()
        {
            Action action = () => new TasksToComplete(1);
            action.Should().NotThrow();
        }

        [Test]
        public void ThrowsAnArgumentExceptionWhenPassedAnInvalidNumber()
        {
            Action action = () => new TasksToComplete(-1);
            action.Should().ThrowExactly<ArgumentException>();
        }

        [Test]
        public void ValueReturnsTheExpectedResult()
        {
            const int expectedTasksToComplete = 5;
            var tasksToComplete = new TasksToComplete(expectedTasksToComplete);
            tasksToComplete.Value().Should().Be(expectedTasksToComplete);
        }
    }
}

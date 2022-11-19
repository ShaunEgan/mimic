using System;
using Domain.ValueObjects;
using NUnit.Framework;

namespace DomainUnitTests.ValueObjects
{
    public class IterationSpecificationTest
    {
        [Test]
        public void TestValidIterations()
        {
            var _ = new SimulationsToExecute(1);
        }

        [Test]
        public void TestZeroIterations()
        {
            try
            {
                var _ = new SimulationsToExecute(0);
                Assert.Fail("Expected an Exception to be thrown");
            }
            catch (ArgumentException)
            {
                Assert.Pass();
            }
            catch (Exception)
            {
                Assert.Fail("Expected an ArgumentException to be thrown");
            }
        }

        [Test]
        public void ValueReturnsTheExpectedResult()
        {
            const int expectedIterations = 5;
            var iterationSpecification = new SimulationsToExecute(expectedIterations);
            Assert.AreEqual(expectedIterations, iterationSpecification.Value());
        }
    }
}

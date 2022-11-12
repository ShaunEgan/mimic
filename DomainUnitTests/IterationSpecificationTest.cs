using System;
using Domain;
using NUnit.Framework;

namespace DomainUnitTests
{
    public class IterationSpecificationTest
    {
        [Test]
        public void TestValidIterations()
        {
            var _ = new IterationSpecification(1);
        }

        [Test]
        public void TestZeroIterations()
        {
            try
            {
                var _ = new IterationSpecification(0);
                Assert.Fail("Expected an Exception to be thrown");
            }
            catch (ArgumentException _)
            {
                Assert.Pass();
            }
            catch (Exception _)
            {
                Assert.Fail("Expected an ArgumentException to be thrown");
            }
        }

        [Test]
        public void ValueReturnsTheExpectedResult()
        {
            const int expectedIterations = 5;
            var iterationSpecification = new IterationSpecification(expectedIterations);
            Assert.AreEqual(expectedIterations, iterationSpecification.Value());
        }
    }
}

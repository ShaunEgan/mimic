using Domain.ValueObjects;
using NUnit.Framework;

namespace DomainUnitTests.ValueObjects
{
    public class RecordTest
    {
        [Test]
        public void TestZeroCompletedTasks()
        {
            var _ = new CompletedTasks(0);
        }

        [Test]
        public void TestValidNumberOfCompletedTasks()
        {
            var _ = new CompletedTasks(10);
        }

        [Test]
        public void ValueReturnsTheExpectedResult()
        {
            const int expectedCompletedTasks = 5;
            var record = new CompletedTasks(expectedCompletedTasks);
            Assert.AreEqual(expectedCompletedTasks, record.Value());
        }
    }
}

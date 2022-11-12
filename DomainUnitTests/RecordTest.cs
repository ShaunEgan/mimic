using Domain;
using NUnit.Framework;

namespace DomainUnitTests
{
    public class RecordTest
    {
        [Test]
        public void TestZeroCompletedTasks()
        {
            var _ = new Record(0);
        }

        [Test]
        public void TestValidNumberOfCompletedTasks()
        {
            var _ = new Record(10);
        }
    }
}

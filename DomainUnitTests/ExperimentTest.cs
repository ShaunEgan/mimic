using System.Linq;
using Domain;
using NUnit.Framework;

namespace DomainUnitTests
{
    public class ExperimentTest
    {
        private readonly int _iterations = 10000;
        
        [Test]
        public void TestResultSizeMatchesIterationSize()
        {
            const int iterations = 10;
            
            var history = new History();
            history.AddRecord(new Record(1));

            var experiment = new ExperimentBuilder()
                .History(history)
                .Iterations(_iterations)
                .Backlog(1)
                .GetExperiment();

            var result = experiment.Run()
                .GetExperimentResults()
                .ToList();
            
            Assert.AreEqual(_iterations, result.Count);
        }
    }
}

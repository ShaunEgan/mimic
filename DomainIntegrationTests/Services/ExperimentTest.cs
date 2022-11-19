using System.Linq;
using Domain.Services;
using Domain.ValueObjects;
using Domain.ValueObjects.History;
using NUnit.Framework;

namespace DomainIntegrationTests.Services
{
    public class ExperimentTest
    {
        private const int Iterations = 10000;
        
        [Test]
        public void TestResultSizeMatchesIterationSize()
        {
            var history = new History();
            history.AddTasksCompletedInACycle(new CompletedTasks(1));

            var sampler = new RandomHistoricalSampler(history);

            var experiment = new ExperimentBuilder()
                .Sampler(sampler)
                .SimulationsToExecute(Iterations)
                .TasksToComplete(1)
                .GetExperiment();

            var result = experiment.Run()
                .Value()
                .ToList();

            Assert.AreEqual(Iterations, result.Count);
        }
    }
}

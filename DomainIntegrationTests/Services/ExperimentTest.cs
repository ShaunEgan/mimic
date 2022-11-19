using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Abstractions;
using Domain.Services;
using Domain.ValueObjects;
using Domain.ValueObjects.History;
using NUnit.Framework;

namespace DomainIntegrationTests.Services
{
    public class ExperimentTest
    {
        private const int SimulationsToExecute = 1000;
        private const int TasksToComplete = 15;
        
        private History _history;
        private ISampler<CompletedTasks> _sampler;
        private Experiment _experiment;
        private IEnumerable<CyclesUsed> _result;

        [SetUp]
        public void ExperimentOutlierTestSetup()
        {
            _history = new History();
            _history.AddTasksCompletedInACycle(new CompletedTasks(1));
            _history.AddTasksCompletedInACycle(new CompletedTasks(2));
            _history.AddTasksCompletedInACycle(new CompletedTasks(3));

            _sampler = new RandomHistoricalSampler(_history);
            
            _experiment = new ExperimentBuilder()
                .Sampler(_sampler)
                .SimulationsToExecute(SimulationsToExecute)
                .TasksToComplete(TasksToComplete)
                .GetExperiment();

            _result = _experiment.Run()
                .Value();
        }

        [Test]
        public void ThereIsAResultForEachCycle()
        {
            Assert.That(_result, Has.Count.EqualTo(SimulationsToExecute));
        }
    }
}

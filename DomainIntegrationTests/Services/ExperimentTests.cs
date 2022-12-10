using System.Collections.Generic;
using Domain.Abstractions;
using Domain.Services;
using Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace DomainIntegrationTests.Services;

public class ExperimentTests
{
    private const int SimulationsToExecute = 1000;
    private const int TasksToComplete = 15;

    private readonly IEnumerable<CyclesUsed> _result;

    public ExperimentTests()
    {
        var history = new History();
        history.AddTasksCompletedInACycle(new CompletedTasks(1));
        history.AddTasksCompletedInACycle(new CompletedTasks(2));
        history.AddTasksCompletedInACycle(new CompletedTasks(3));

        ISampler<CompletedTasks> sampler = new RandomHistoricalSampler(history);

        var experiment = new ExperimentBuilder()
            .Sampler(sampler)
            .SimulationsToExecute(SimulationsToExecute)
            .TasksToComplete(TasksToComplete)
            .GetExperiment();

        _result = experiment.Run()
            .Value();
    }

    [Fact]
    public void ThereIsAResultForEachCycle()
    {
        _result.Should().HaveCount(SimulationsToExecute);
    }

    [Fact]
    public void TheResultsAreInAscendingOrder()
    {
        _result.Should().BeInAscendingOrder();
    }
}

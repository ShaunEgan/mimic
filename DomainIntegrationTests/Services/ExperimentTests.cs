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
        var burndownHistory = new BurndownHistory();
        burndownHistory.AddTasksCompletedInACycle(new CompletedTasks(1));
        burndownHistory.AddTasksCompletedInACycle(new CompletedTasks(2));
        burndownHistory.AddTasksCompletedInACycle(new CompletedTasks(3));

        var regressionHistory = new RegressionHistory();
        regressionHistory.AddTasksAddedInACycle(new AddedTasks(0));
        regressionHistory.AddTasksAddedInACycle(new AddedTasks(1));
        regressionHistory.AddTasksAddedInACycle(new AddedTasks(0));

        ISampler<CompletedTasks> burndownSampler = new RandomHistoricalSampler(burndownHistory);
        ISampler<AddedTasks> regressionSampler = new RandomRegressionSampler(regressionHistory);

        var experiment = new ExperimentBuilder()
            .BurndownSampler(burndownSampler)
            .RegressionSampler(regressionSampler)
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

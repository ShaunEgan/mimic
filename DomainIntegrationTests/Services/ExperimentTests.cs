using System.Collections.Generic;
using Domain.Experiments;
using Domain.History;
using Domain.History.Samplers;
using Domain.Tasks;
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
        burndownHistory.Add(new CompletedTasks(1));
        burndownHistory.Add(new CompletedTasks(2));
        burndownHistory.Add(new CompletedTasks(3));

        var regressionHistory = new RegressionHistory();
        regressionHistory.Add(new AddedTasks(0));
        regressionHistory.Add(new AddedTasks(1));
        regressionHistory.Add(new AddedTasks(0));

        ISampler<CompletedTasks> burndownSampler = new CompletedTasksRandomSampler(burndownHistory);
        ISampler<AddedTasks> regressionSampler = new RegressionRandomSampler(regressionHistory);

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

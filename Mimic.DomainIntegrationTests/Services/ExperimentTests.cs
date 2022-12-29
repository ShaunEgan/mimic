using System.Collections.Generic;
using Mimic.Domain.Experiments;
using Mimic.Domain.Experiments.Configuration;
using Mimic.Domain.History;
using Mimic.Domain.History.Samplers;
using Mimic.Domain.Tasks;
using FluentAssertions;
using Xunit;

namespace Mimic.DomainIntegrationTests.Services;

public class ExperimentTests
{
    private const int SimulationsToExecute = 1000;
    private const int TasksToComplete = 15;

    private readonly IEnumerable<CyclesUsed> _result;

    public ExperimentTests()
    {
        var burndownHistory = new BurndownHistory();
        burndownHistory.From(new[]
        {
            new CompletedTasks(1),
            new CompletedTasks(2),
            new CompletedTasks(3)
        });

        var regressionHistory = new RegressionHistory();
        regressionHistory.From(new[]
        {
            new AddedTasks(0),
            new AddedTasks(1),
            new AddedTasks(0),
        });

        var configuration = new Configuration
        {
            TasksToComplete = new TasksToComplete(TasksToComplete),
            BurndownSampler = new CompletedTasksRandomSampler(burndownHistory),
            RegressionSampler = new RegressionRandomSampler(regressionHistory),
            SimulationsToExecute = new SimulationsToExecute(SimulationsToExecute),
            MaxCycles = new MaxCycles()
        };

        var experiment = new Experiment(configuration);

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

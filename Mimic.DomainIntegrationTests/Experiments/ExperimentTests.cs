using System.Collections.Generic;
using Mimic.Domain.Experiments;
using Mimic.Domain.Experiments.Configuration;
using Mimic.Domain.History;
using Mimic.Domain.History.Samplers;
using FluentAssertions;
using Mimic.Domain.Report;
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
            new Tasks(1),
            new Tasks(2),
            new Tasks(3)
        });

        var regressionHistory = new RegressionHistory();
        regressionHistory.From(new[]
        {
            new Tasks(0),
            new Tasks(1),
            new Tasks(0),
        });

        var configuration = new Configuration
        {
            TasksToComplete = new TasksToComplete(TasksToComplete),
            BurndownSampler = new HistoryRandomSampler(burndownHistory),
            RegressionSamplers = new [] { new HistoryRandomSampler(regressionHistory) },
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

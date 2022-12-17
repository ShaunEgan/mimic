using System.Collections.Generic;
using Domain.Experiments;
using Domain.Experiments.Configuration;
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

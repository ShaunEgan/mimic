using Domain.Abstractions;
using Domain.ValueObjects;
using Domain.ValueObjects.ExperimentResults;
using Domain.ValueObjects.History;

namespace Domain.Services;

public interface IBuilder
{
    IBuilder SimulationsToExecute(int simulationsToExecute);

    IBuilder Sampler(ISampler<CompletedTasks> sampler);

    IBuilder TasksToComplete(int tasksToComplete);

    Experiment GetExperiment();
}

public class ExperimentBuilder : IBuilder
{
    private Experiment _experiment = new Experiment();

    public ExperimentBuilder()
    {
        Reset();
    }

    private void Reset()
    {
        _experiment = new Experiment();
    }

    public IBuilder SimulationsToExecute(int simulationsToExecute)
    {
        _experiment.SimulationsToExecute = new SimulationsToExecute(simulationsToExecute);
        return this;
    }

    public IBuilder Sampler(ISampler<CompletedTasks> sampler)
    {
        _experiment.Sampler = sampler;
        return this;
    }

    public IBuilder TasksToComplete(int tasksToComplete)
    {
        _experiment.TasksToComplete = new TasksToComplete(tasksToComplete);
        return this;
    }

    public Experiment GetExperiment()
    {
        var experiment = _experiment;
        Reset();
        return experiment;
    }
}

/// <summary>
/// An experiment can be used to execute an arbitrary number of simulations
/// </summary>
public class Experiment
{
    internal SimulationsToExecute SimulationsToExecute;
    internal TasksToComplete TasksToComplete;
    internal ISampler<CompletedTasks> Sampler;

    public ExperimentResults Run()
    {
        var results = new ExperimentResults();

        for (var i = 0; i < SimulationsToExecute.Value(); i++)
        {
            var simulation = new Simulation(TasksToComplete, Sampler);
            var cyclesUsed = simulation.Execute();
            results.AddSimulationResult(cyclesUsed);
        }

        return results;
    }
}

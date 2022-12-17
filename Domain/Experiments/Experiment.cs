using Domain.Experiments.Configuration;
using Domain.History.Samplers;
using Domain.Tasks;

namespace Domain.Experiments;

public interface IBuilder
{
    IBuilder SimulationsToExecute(int simulationsToExecute);

    IBuilder BurndownSampler(ISampler<CompletedTasks> sampler);

    IBuilder RegressionSampler(ISampler<AddedTasks> sampler);

    IBuilder TasksToComplete(int tasksToComplete);

    IBuilder MaxCycles(int maxCycles);
    
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

    public IBuilder BurndownSampler(ISampler<CompletedTasks> sampler)
    {
        _experiment.BurndownSampler = sampler;
        return this;
    }

    public IBuilder RegressionSampler(ISampler<AddedTasks> sampler)
    {
        _experiment.RegressionSampler = sampler;
        return this;
    }

    public IBuilder TasksToComplete(int tasksToComplete)
    {
        _experiment.TasksToComplete = new TasksToComplete(tasksToComplete);
        return this;
    }

    public IBuilder MaxCycles(int maxCycles)
    {
        _experiment.MaxCycles = new MaxCycles(maxCycles);
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
    internal ISampler<CompletedTasks> BurndownSampler;
    internal ISampler<AddedTasks> RegressionSampler;
    internal MaxCycles MaxCycles;

    public Results Run()
    {
        MaxCycles ??= new MaxCycles();
        
        var results = new Results();

        for (var i = 0; i < SimulationsToExecute.Value(); i++)
        {
            var simulation = new Simulation(TasksToComplete, BurndownSampler, RegressionSampler, MaxCycles);
            var cyclesUsed = simulation.Execute();
            results.AddSimulationResult(cyclesUsed);
        }

        return results;
    }
}

using Domain.Experiments.Configuration;
using Domain.History.Samplers;
using Domain.Tasks;

namespace Domain.Experiments;

/// <summary>
/// An experiment can be used to execute an arbitrary number of simulations
/// </summary>
public class Experiment
{
    private readonly SimulationsToExecute _simulationsToExecute;
    private readonly TasksToComplete _tasksToComplete;
    private readonly ISampler<CompletedTasks> _burndownSampler;
    private readonly ISampler<AddedTasks> _regressionSampler;
    private readonly MaxCycles _maxCycles;

    public Experiment(Configuration.Configuration configuration)
    {
        _simulationsToExecute = configuration.SimulationsToExecute;
        _tasksToComplete = configuration.TasksToComplete;
        _burndownSampler = configuration.BurndownSampler;
        _regressionSampler = configuration.RegressionSampler;
        _maxCycles = configuration.MaxCycles;
    }

    public Results Run()
    {
        var results = new Results();

        for (var i = 0; i < _simulationsToExecute.Value(); i++)
        {
            var simulation = new Simulation(_tasksToComplete, _burndownSampler, _regressionSampler, _maxCycles);
            var cyclesUsed = simulation.Execute();
            results.AddSimulationResult(cyclesUsed);
        }

        return results;
    }
}

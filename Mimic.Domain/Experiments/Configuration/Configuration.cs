using Mimic.Domain.History.Samplers;
using Mimic.Domain.Tasks;

namespace Mimic.Domain.Experiments.Configuration;

/// <summary>
/// Configures an experiment.
/// </summary>
public class Configuration
{
    public required SimulationsToExecute SimulationsToExecute { get; init; }
    public required TasksToComplete TasksToComplete { get; init; }
    public required ISampler<CompletedTasks> BurndownSampler { get; init; }
    public required ISampler<AddedTasks> RegressionSampler { get; init; }
    public required MaxCycles MaxCycles { get; init; }
}

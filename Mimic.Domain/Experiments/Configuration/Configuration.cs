using Mimic.Domain.History;
using Mimic.Domain.History.Samplers;

namespace Mimic.Domain.Experiments.Configuration;

/// <summary>
/// Configures an experiment.
/// </summary>
public class Configuration
{
    public required SimulationsToExecute SimulationsToExecute { get; init; }
    public required TasksToComplete TasksToComplete { get; init; }
    public required ISampler<Tasks> BurndownSampler { get; init; }
    public required ISampler<Tasks> RegressionSampler { get; init; }
    public required MaxCycles MaxCycles { get; init; }
}

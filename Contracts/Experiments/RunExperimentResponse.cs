namespace Contracts.Experiments;

public record RunExperimentResponse(
    int[] ProbabilityBuckets,
    int[] SimulationResults
);

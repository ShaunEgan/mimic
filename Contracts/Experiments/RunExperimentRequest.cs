namespace Contracts.Experiments;

public record RunExperimentRequest(
    int TasksToComplete,
    int SimulationsToExecute,
    int MaxCycles,
    int[] BurndownHistory,
    RegressionRequest[] CycleRegressions
);

public record RegressionRequest(
    int[] Data
);

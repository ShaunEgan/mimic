using Domain.Experiments;
using MediatR;

namespace Application.Experiments.Commands.RunExperiment;

public record RunExperimentCommand(
    int TasksToComplete,
    int SimulationsToExecute,
    int MaxCycles,
    int[] BurndownHistory,
    RegressionCommand[] CycleRegressions
) : IRequest<ExperimentResults>;

public record RegressionCommand(
    int[] Data
);

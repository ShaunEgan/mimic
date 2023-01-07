using Mimic.Domain.Experiments;
using MediatR;
using Mimic.Domain.Report;

namespace Mimic.Application.Experiments.Commands.RunExperiment;

public record RunExperimentCommand(
    int TasksToComplete,
    int SimulationsToExecute,
    int MaxCycles,
    int[] BurndownHistory,
    RegressionCommand[] CycleRegressions
) : IRequest<Report>;

public record RegressionCommand(
    int[] Data
);

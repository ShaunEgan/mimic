using Mimic.Domain.Experiments;
using Mimic.Domain.Experiments.Configuration;
using Mimic.Domain.History;
using Mimic.Domain.History.Samplers;
using MediatR;
using Mimic.Domain.Report;

namespace Mimic.Application.Experiments.Commands.RunExperiment;

public class RunExperimentCommandHandler : IRequestHandler<RunExperimentCommand, Report>
{
    public Task<Report> Handle(RunExperimentCommand command, CancellationToken cancellationToken)
    {
        var burndownHistory = new BurndownHistory();
        burndownHistory.From(command.BurndownHistory.Select(x => new Tasks(x)));
        var burndownSampler = new HistoryRandomSampler(burndownHistory);
        
        var regressionSamplers = command.CycleRegressions.Select(cycleRegression =>
        {
            var regressionHistory = new RegressionHistory();
            regressionHistory.From(cycleRegression.Data.Select(x => new Tasks(x)));

            var historyRandomSampler = new HistoryRandomSampler(regressionHistory);
            return historyRandomSampler;
        });

        var configuration = new Configuration
        {
            TasksToComplete = new TasksToComplete(command.TasksToComplete),
            BurndownSampler = burndownSampler,
            RegressionSamplers = regressionSamplers,
            SimulationsToExecute = new SimulationsToExecute(command.SimulationsToExecute),
            MaxCycles = new MaxCycles(command.MaxCycles)
        };
        
        var experiment = new Experiment(configuration);
        return Task.FromResult(experiment.Run());
    }
}


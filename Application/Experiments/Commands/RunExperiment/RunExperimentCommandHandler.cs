using Domain.Experiments;
using Domain.Experiments.Configuration;
using Domain.History;
using Domain.History.Samplers;
using Domain.Tasks;
using MediatR;

namespace Application.Experiments.Commands.RunExperiment;

public class RunExperimentCommandHandler : IRequestHandler<RunExperimentCommand, ExperimentResults>
{
    public Task<ExperimentResults> Handle(RunExperimentCommand command, CancellationToken cancellationToken)
    {
        var burndownHistory = new BurndownHistory();
        burndownHistory.From(command.BurndownHistory.Select(x => new CompletedTasks(x)));
        
        var regressionHistory = new RegressionHistory();
        regressionHistory.From(command.CycleRegressions.First().Data.Select(x => new AddedTasks(x)));

        var configuration = new Configuration
        {
            TasksToComplete = new TasksToComplete(command.TasksToComplete),
            BurndownSampler = new CompletedTasksRandomSampler(burndownHistory),
            RegressionSampler = new RegressionRandomSampler(regressionHistory),
            SimulationsToExecute = new SimulationsToExecute(command.SimulationsToExecute),
            MaxCycles = new MaxCycles(command.MaxCycles)
        };
        
        var experiment = new Experiment(configuration);
        return Task.FromResult(experiment.Run());
    }
}


using FluentValidation;

namespace Application.Experiments.Commands.RunExperiment;

public class RunExperimentCommandValidator : AbstractValidator<RunExperimentCommand>
{
    public RunExperimentCommandValidator()
    {
        RuleFor(x => x.TasksToComplete).NotEmpty().GreaterThan(0).LessThanOrEqualTo(10000);
        RuleFor(x => x.SimulationsToExecute).NotEmpty().GreaterThan(0).LessThanOrEqualTo(100000);
        RuleFor(x => x.MaxCycles).NotEmpty().GreaterThan(0).LessThanOrEqualTo(100000);
        RuleFor(x => x.BurndownHistory).NotEmpty();
    }
}

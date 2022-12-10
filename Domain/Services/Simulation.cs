using Domain.Abstractions;
using Domain.ValueObjects;

namespace Domain.Services;

public class Simulation
{
    private readonly TasksToComplete _tasksToComplete;
    private readonly ISampler<CompletedTasks> _sampler;

    public Simulation(TasksToComplete tasksToComplete, ISampler<CompletedTasks> sampler)
    {
        _tasksToComplete = tasksToComplete;
        _sampler = sampler;
    }

    public CyclesUsed Execute()
    {
        var cycles = 0;
        var remaining = _tasksToComplete.Value();

        while (remaining > 0)
        {
            cycles++;

            var sample = _sampler.NextSample().Value();
            remaining -= (int)sample;
        }

        return new CyclesUsed(cycles);
    }
}

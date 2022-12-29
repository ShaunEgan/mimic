using System;
using Mimic.Domain.Experiments.Configuration;
using Mimic.Domain.History.Samplers;
using Mimic.Domain.Tasks;

namespace Mimic.Domain.Experiments;

public class Simulation
{
    private readonly TasksToComplete _tasksToComplete;
    private readonly ISampler<CompletedTasks> _burndownSampler;
    private readonly ISampler<AddedTasks> _regressionSampler;
    private readonly MaxCycles _maxCycles;

    public Simulation(TasksToComplete tasksToComplete, ISampler<CompletedTasks> burndownSampler,
        ISampler<AddedTasks> regressionSampler, MaxCycles maxCycles)
    {
        _tasksToComplete = tasksToComplete;
        _burndownSampler = burndownSampler;
        _regressionSampler = regressionSampler;
        _maxCycles = maxCycles;
    }

    public CyclesUsed Execute()
    {
        var cycles = 0;
        var remaining = _tasksToComplete.Value();

        while (remaining > 0)
        {
            cycles++;

            if (cycles > _maxCycles.Value()) throw new Exception("Simulation exceeded configured number of max cycles");

            var completedTasks = _burndownSampler.NextSample().Value();
            remaining -= completedTasks;

            var regressionTasks = _regressionSampler.NextSample().Value();
            remaining += regressionTasks;
        }

        return new CyclesUsed(cycles);
    }
}

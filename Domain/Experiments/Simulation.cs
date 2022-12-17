using System;
using Domain.Experiments.Configuration;
using Domain.History.Samplers;
using Domain.Tasks;

namespace Domain.Experiments;

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
            remaining -= (int)completedTasks;

            if (_regressionSampler == null) continue;

            var regressionTasks = _regressionSampler.NextSample().Value();
            remaining += (int)regressionTasks;
        }

        return new CyclesUsed(cycles);
    }
}

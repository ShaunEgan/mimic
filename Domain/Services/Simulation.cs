using System;
using Domain.Abstractions;
using Domain.ValueObjects;

namespace Domain.Services;

public class Simulation
{
    private readonly TasksToComplete _tasksToComplete;
    private readonly ISampler<CompletedTasks> _burndownSampler;
    private readonly ISampler<AddedTasks> _regressionSampler;
    private readonly int _maxCycles;

    public Simulation(TasksToComplete tasksToComplete, ISampler<CompletedTasks> burndownSampler, ISampler<AddedTasks> regressionSampler, int maxCycles = 1000)
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

            if (cycles > _maxCycles) throw new Exception("Unstable burndown encountered");

            var completedTasks = _burndownSampler.NextSample().Value();
            remaining -= (int)completedTasks;

            if (_regressionSampler == null) continue;
            
            var regressionTasks = _regressionSampler.NextSample().Value();
            remaining += (int)regressionTasks;
        }

        return new CyclesUsed(cycles);
    }
}

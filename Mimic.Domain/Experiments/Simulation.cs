using System;
using Mimic.Domain.Experiments.Configuration;
using Mimic.Domain.History.Samplers;
using Mimic.Domain.History;

namespace Mimic.Domain.Experiments;

public class Simulation
{
    private readonly TasksToComplete _tasksToComplete;
    private readonly ISampler<Tasks> _burndownSampler;
    private readonly ISampler<Tasks>[] _regressionSamplers;
    private readonly MaxCycles _maxCycles;

    public Simulation(TasksToComplete tasksToComplete, ISampler<Tasks> burndownSampler,
        ISampler<Tasks>[] regressionSamplers, MaxCycles maxCycles)
    {
        _tasksToComplete = tasksToComplete;
        _burndownSampler = burndownSampler;
        _regressionSamplers = regressionSamplers;
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

            foreach (var regressionSampler in _regressionSamplers)
            {
                var regressionTasks = regressionSampler.NextSample().Value();
                remaining += regressionTasks;
            }
        }

        return new CyclesUsed(cycles);
    }
}

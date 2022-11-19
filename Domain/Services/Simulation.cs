using System;
using System.Linq;
using Domain.ValueObjects;
using Domain.ValueObjects.History;

namespace Domain.Services
{
    public class Simulation
    {
        private readonly History _history;
        private readonly TasksToComplete _tasksToComplete;

        public Simulation(History history, TasksToComplete tasksToComplete)
        {
            _history = history;
            _tasksToComplete = tasksToComplete;
        }

        public CyclesUsed Execute()
        {
            var cycles = 0;

            var samples = _history.Value().ToArray();
            var remaining = _tasksToComplete.Value();

            while (remaining > 0)
            {
                cycles++;

                var random = new Random();
                var index = random.Next(0, samples.Length);
                var sample = samples[index].Value();
                
                remaining -= (int)sample;
            }

            return new CyclesUsed(cycles);
        }
    }
}

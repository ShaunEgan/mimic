using System;
using System.Linq;
using Domain.ValueObjects;
using Domain.ValueObjects.ExperimentResults;
using Domain.ValueObjects.History;

namespace Domain.Services
{
    public interface IBuilder
    {
        IBuilder Iterations(int iterations);

        IBuilder History(History history);

        IBuilder Backlog(int items);

        Experiment GetExperiment();
    }

    public class ExperimentBuilder : IBuilder
    {
        private Experiment _experiment = new Experiment();

        public ExperimentBuilder()
        {
            Reset();
        }

        private void Reset()
        {
            _experiment = new Experiment();
        }

        public IBuilder Iterations(int iterations)
        {
            _experiment.SimulationsToExecute = new SimulationsToExecute(iterations);
            return this;
        }

        public IBuilder History(History history)
        {
            _experiment.History = history;
            return this;
        }

        public IBuilder Backlog(int items)
        {
            _experiment.TasksToComplete = new TasksToComplete(items);
            return this;
        }

        public Experiment GetExperiment()
        {
            var result = _experiment;
            Reset();
            return result;
        }
    }

    /// <summary>
    /// An experiment can be used to execute an arbitrary number of simulations, providing confidence intervals for burn
    /// down.
    /// </summary>
    public class Experiment
    {
        internal SimulationsToExecute SimulationsToExecute;
        internal History History;
        internal TasksToComplete TasksToComplete;

        public ExperimentResults Run()
        {
            var results = new ExperimentResults();

            for (var i = 0; i < SimulationsToExecute.Value(); i++)
            {
                results.AddSimulationResult(Simulate());
            }

            return results;
        }

        private CyclesUsed Simulate()
        {
            var cycles = 0;

            var samples = History.Value().ToArray();
            var remaining = TasksToComplete.Value();

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

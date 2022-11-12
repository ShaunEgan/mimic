using System;

namespace Domain
{
    public interface IBuilder
    {
        void Iterations(int iterations);
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

        public void Iterations(int iterations)
        {
            _experiment.IterationSpecification = new IterationSpecification(iterations);
        }

        public Experiment GetSimulation()
        {
            var result = this._experiment;
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
        internal IterationSpecification IterationSpecification;
    }
}

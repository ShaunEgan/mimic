using System;

namespace Domain
{
    public interface IBuilder
    {
        void Iterations(int iterations);
    }

    public class SimulationBuilder : IBuilder
    {
        private Simulation _simulation = new Simulation();

        public SimulationBuilder()
        {
            Reset();
        }

        private void Reset()
        {
            _simulation = new Simulation();
        }

        public void Iterations(int iterations)
        {
            _simulation.IterationSpecification = new IterationSpecification(iterations);
        }

        public Simulation GetSimulation()
        {
            var result = this._simulation;
            Reset();
            return result;
        }
    }

    public class Simulation
    {
        internal IterationSpecification IterationSpecification;
    }
}

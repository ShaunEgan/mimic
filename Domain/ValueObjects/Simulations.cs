using System;

namespace Domain.ValueObjects
{
    /// <summary>
    /// The minimum number of simulations to run for the experiment
    /// </summary>
    public class Simulations : IValueObject<int>
    {
        /// <summary>
        /// The minimum number of iterations that the experiment must run
        /// </summary>
        private readonly uint _simulations;

        /// <summary>
        /// Specify the number of simulations to run for the experiment.
        /// 
        /// This number must be a positive integer greater than 0.
        /// </summary>
        /// <param name="simulations">The minimum number of iterations</param>
        /// <exception cref="ArgumentException">Thrown when the number of iterations is not a positive integer greater than 0</exception>
        public Simulations(int simulations)
        {
            if (simulations < 1)
            {
                throw new ArgumentException("Simulations must be a positive integer higher than 0");
            }

            _simulations = (uint)simulations;
        }

        /// <summary>
        /// Get the number of simulations that the experiment should run
        /// </summary>
        /// <returns></returns>
        public int Value()
        {
            return (int)_simulations;
        }
    }
}
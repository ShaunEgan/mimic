using System;

namespace Domain
{
    /// <summary>
    /// Represents the minimum number of iterations that a simulation must run.
    /// </summary>
    public class IterationSpecification
    {
        /// <summary>
        /// The minimum number of iterations the simulation should run.
        /// </summary>
        private readonly uint _iterations;

        /// <summary>
        /// Specify the number of iterations required of the simulation.
        /// 
        /// This number must be a positive integer greater than 0.
        /// </summary>
        /// <param name="iterations">The minimum number of iterations</param>
        /// <exception cref="ArgumentException">Thrown when the number of iterations is not a positive integer greater than 0</exception>
        public IterationSpecification(int iterations)
        {
            if (iterations < 1)
            {
                throw new ArgumentException("Iterations must be a positive integer higher than 0");
            }

            _iterations = (uint)iterations;
        }

        /// <summary>
        /// Get the minimum number of iterations that the simulation should run.
        /// </summary>
        /// <returns></returns>
        public int Value()
        {
            return (int)_iterations;
        }
    }
}

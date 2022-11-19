using System;

namespace Domain.ValueObjects
{
    /// <summary>
    /// Represents the number of cycles used to burndown a set of tasks
    /// </summary>
    public class CyclesUsed : IValueObject<int>
    {
        /// <summary>
        /// The number of cycles used to complete the set of tasks
        /// </summary>
        private readonly uint _cyclesUsed;

        /// <summary>
        /// Create an instance of CyclesUsed which represents the number of cycles used to burndown a set of tasks
        /// </summary>
        /// <param name="cyclesUsed"></param>
        /// <exception cref="ArgumentException"></exception>
        public CyclesUsed(int cyclesUsed)
        {
            if (cyclesUsed < 1)
            {
                throw new ArgumentException("Cycles used must be a positive integer");
            }

            _cyclesUsed = (uint)cyclesUsed;
        }

        /// <summary>
        /// Get the number of cycles used to complete the set of tasks
        /// </summary>
        /// <returns></returns>
        public int Value()
        {
            return (int)_cyclesUsed;
        }
    }
}
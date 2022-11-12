using System;

namespace Domain
{
    /// <summary>
    /// Represents the number of tasks completed in a given cycle
    /// </summary>
    public class Record
    {
        /// <summary>
        /// The number of tasks completed
        /// </summary>
        private readonly uint _completedTasks;

        /// <summary>
        /// Create an instance of Record, which represents the number of tasks completed in a given cycle
        /// </summary>
        /// <param name="completedTasks">The number of tasks completed in the given cycle</param>
        public Record(uint completedTasks)
        {
            _completedTasks = completedTasks;
        }

        /// <summary>
        /// Get the number of tasks completed
        /// </summary>
        /// <returns>The number of completed tasks</returns>
        public uint Value()
        {
            return _completedTasks;
        }
    }
}

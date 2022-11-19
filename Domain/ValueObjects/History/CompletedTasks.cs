using Domain.ValueObjects.Abstractions;

namespace Domain.ValueObjects
{
    /// <summary>
    /// Represents the number of tasks completed in a given cycle
    /// </summary>
    public class CompletedTasks : IValueObject<int>
    {
        /// <summary>
        /// The number of tasks completed
        /// </summary>
        private readonly uint _completedTasks;

        /// <summary>
        /// Create an instance of CompletedTasks, which represents the number of tasks completed in a given cycle
        /// </summary>
        /// <param name="completedTasks">The number of tasks completed in the given cycle</param>
        public CompletedTasks(int completedTasks)
        {
            _completedTasks = (uint)completedTasks;
        }

        /// <summary>
        /// Get the number of tasks completed
        /// </summary>
        /// <returns>The number of completed tasks</returns>
        public int Value()
        {
            return (int)_completedTasks;
        }
    }
}
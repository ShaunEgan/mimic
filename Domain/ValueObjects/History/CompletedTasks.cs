using System;
using Domain.Abstractions;

namespace Domain.ValueObjects.History;

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
        if (completedTasks < 0)
        {
            throw new ArgumentException("CompletedTasks must be a zero or higher");
        }

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

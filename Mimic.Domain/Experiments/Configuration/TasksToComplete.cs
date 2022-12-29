using System;
using Mimic.Domain.Abstractions;

namespace Mimic.Domain.Experiments.Configuration;

/// <summary>
/// The number of tasks required to be completed.
/// </summary>
public class TasksToComplete : IValueObject<int>
{
    /// <summary>
    /// The number of tasks to be completed.
    /// </summary>
    private readonly uint _tasks;

    /// <summary>
    /// A number of tasks to be completed.
    /// </summary>
    /// <param name="tasks"></param>
    /// <exception cref="ArgumentException"></exception>
    public TasksToComplete(int tasks)
    {
        var tasksAreZeroOrHigher = tasks >= 0;
        if (!tasksAreZeroOrHigher)
        {
            throw new ArgumentException("Tasks to complete must be 0 or higher integer");
        }

        _tasks = (uint)tasks;
    }

    /// <summary>
    /// Get the number of tasks required to be completed.
    /// </summary>
    /// <returns></returns>
    public int Value()
    {
        return (int)_tasks;
    }
}

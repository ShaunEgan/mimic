using System.Collections.Generic;
using System.Linq;
using Domain.Abstractions;

namespace Domain.ValueObjects;

/// <summary>
/// A team's burndown history over n cycles
/// </summary>
public class History : IValueObject<IEnumerable<CompletedTasks>>
{
    /// <summary>
    /// The tasks completed by a team over n cycles
    /// </summary>
    private IEnumerable<CompletedTasks> _history = new List<CompletedTasks>();

    /// <summary>
    /// Add a record of the number of tasks completed by the team in a single cycle
    /// </summary>
    /// <param name="completedTasks">The number of tasks completed in a single cycle</param>
    public void AddTasksCompletedInACycle(CompletedTasks completedTasks)
    {
        _history = _history.Append(completedTasks);
    }

    /// <summary>
    /// Get the full output history of the team for the given cycles
    /// </summary>
    /// <returns></returns>
    public IEnumerable<CompletedTasks> Value()
    {
        return _history;
    }
}

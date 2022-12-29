using System.Collections.Generic;
using System.Linq;

namespace Mimic.Domain.History;

/// <summary>
/// Represents the history of some feature over cycles.
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class History<T> : IHistory<T>
{
    private IEnumerable<T> _history = new List<T>();

    /// <summary>
    /// Add a single cycles recording of the feature
    /// </summary>
    /// <param name="tasks"></param>
    public void Add(T tasks)
    {
        _history = _history.Append(tasks);
    }

    /// <summary>
    /// Add recordings of multiple cycles
    /// </summary>
    /// <param name="tasksHistory"></param>
    public void From(IEnumerable<T> tasksHistory)
    {
        _history = _history.Concat(tasksHistory);
    }

    /// <summary>
    /// Get the team's complete history of the feature 
    /// </summary>
    /// <returns>The history of the feature</returns>
    public IEnumerable<T> Value()
    {
        return _history;
    }
}

using System.Collections.Generic;
using System.Linq;

namespace Domain.History;

public abstract class History<T> : IHistory<T>
{
    private IEnumerable<T> _history = new List<T>();

    public void Add(T tasks)
    {
        _history = _history.Append(tasks);
    }

    /// <summary>
    /// Get the team's history of the feature 
    /// </summary>
    /// <returns>The history of the feature</returns>
    public IEnumerable<T> Value()
    {
        return _history;
    }
}

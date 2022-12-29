using System.Collections.Generic;
using Mimic.Domain.Abstractions;

namespace Mimic.Domain.History;

/// <summary>
/// Represents the history of a given feature for a team over n cycles.
/// </summary>
/// <typeparam name="T">A feature of each cycle</typeparam>
public interface IHistory<T> : IValueObject<IEnumerable<T>>
{
    /// <summary>
    /// Add the feature to the team's history
    /// </summary>
    /// <param name="tasks"></param>
    public void Add(T tasks);
}

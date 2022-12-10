using System.Collections.Generic;
using System.Linq;
using Domain.Abstractions;

namespace Domain.ValueObjects;

/// <summary>
/// The results of an experiment
/// </summary>
public class ExperimentResults : IValueObject<IEnumerable<CyclesUsed>>
{
    /// <summary>
    /// The results of the experiment
    /// </summary>
    private readonly List<CyclesUsed> _experimentResults = new();

    /// <summary>
    /// Add a record of how many cycles were used by a simulation to burndown the backlog
    /// </summary>
    /// <param name="cyclesUsed">The number of cycles used to burndown a backlog in a single simulation</param>
    public void AddSimulationResult(CyclesUsed cyclesUsed)
    {
        _experimentResults.Add(cyclesUsed);
    }

    /// <summary>
    /// Get the results of the experiment represented as set of the number of cycles used to burn down the backlog
    /// by each simulation
    /// </summary>
    /// <returns></returns>
    public IEnumerable<CyclesUsed> Value()
    {
        return _experimentResults.OrderBy(c => c.Value()).ToList();
    }
}

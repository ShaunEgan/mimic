using System;
using Domain.Abstractions;

namespace Domain.Experiments.Configuration;

/// <summary>
/// The maximum number of cycles that a the simulation will attempt to use to burn down a set of tasks.
/// </summary>
public class MaxCycles : IValueObject<int>
{
    /// <summary>
    /// The maximum number of cycles a simulation may attempt to burn down a set of tasks.
    /// </summary>
    private readonly uint _maxCycles;

    /// <summary>
    /// Specify the number of cycles that the simulation will attempt to burn down a set of tasks.
    ///
    /// This number must be greater than 0.
    /// This number defaults to 1000.
    /// </summary>
    /// <param name="maxCycles"></param>
    /// <exception cref="ArgumentException"></exception>
    public MaxCycles(int maxCycles = 1000)
    {
        var maxCyclesGreaterThanZero = maxCycles > 0;
        if (!maxCyclesGreaterThanZero)
        {
            throw new ArgumentException("MaxCycles must be greater than 0");
        }

        _maxCycles = (uint)maxCycles;
    }

    /// <summary>
    /// Get the maximum number of cycles that a simulation may use to burn down a set of tasks. 
    /// </summary>
    /// <returns></returns>
    public int Value()
    {
        return (int)_maxCycles;
    }
}

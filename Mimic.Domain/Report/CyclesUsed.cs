using System;
using Mimic.Domain.Abstractions;

namespace Mimic.Domain.Report;

/// <summary>
/// Represents the number of cycles used to burndown a set of tasks
/// </summary>
public class CyclesUsed : IValueObject<int>, IComparable
{
    /// <summary>
    /// The number of cycles used to complete the set of tasks
    /// </summary>
    private readonly uint _cyclesUsed;

    /// <summary>
    /// Create an instance of CyclesUsed which represents the number of cycles used to burndown a set of tasks
    /// </summary>
    /// <param name="cyclesUsed"></param>
    /// <exception cref="ArgumentException"></exception>
    public CyclesUsed(int cyclesUsed)
    {
        if (cyclesUsed < 1)
        {
            throw new ArgumentException("Cycles used must be a positive integer");
        }

        _cyclesUsed = (uint)cyclesUsed;
    }

    /// <summary>
    /// Get the number of cycles used to complete the set of tasks
    /// </summary>
    /// <returns></returns>
    public int Value()
    {
        return (int)_cyclesUsed;
    }

    /// <summary>
    /// Used for ordering
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public int CompareTo(object obj)
    {
        if (obj == null) return 1;

        if (obj is not CyclesUsed otherCyclesUsed) throw new ArgumentException("Object is not CyclesUsed");

        return _cyclesUsed.CompareTo(otherCyclesUsed._cyclesUsed);
    }
}

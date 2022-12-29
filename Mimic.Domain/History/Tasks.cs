using System;
using Mimic.Domain.Abstractions;

namespace Mimic.Domain.History;

/// <summary>
/// Represents some number of tasks
/// </summary>
public class Tasks : IValueObject<int>
{
    private readonly int _tasks;
    
    public Tasks(int tasks)
    {
        if (tasks < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(tasks), "Must be 0 or greater");
        }
        
        _tasks = tasks;
    }

    public int Value()
    {
        return _tasks;
    }
}

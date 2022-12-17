using System;
using Domain.Abstractions;

namespace Domain.ValueObjects;

public class AddedTasks : IValueObject<int>
{
    private readonly uint _addedTasks;
    
    public AddedTasks(int addedTasks)
    {
        if (addedTasks < 0)
        {
            throw new ArgumentException("AddedTasks must be zero or higher");
        }
        
        _addedTasks = (uint)addedTasks;
    }

    public int Value()
    {
        return (int)_addedTasks;
    }
}

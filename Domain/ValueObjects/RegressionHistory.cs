using System.Collections.Generic;
using System.Linq;
using Domain.Abstractions;

namespace Domain.ValueObjects;

public class RegressionHistory : IValueObject<IEnumerable<AddedTasks>>
{
    private IEnumerable<AddedTasks> _history = new List<AddedTasks>();

    public void AddTasksAddedInACycle(AddedTasks addedTasks)
    {
        _history = _history.Append(addedTasks);
    }

    public IEnumerable<AddedTasks> Value()
    {
        return _history;
    }
}

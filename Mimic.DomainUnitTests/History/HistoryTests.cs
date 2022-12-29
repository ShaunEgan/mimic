using System.Collections.Generic;
using Mimic.Domain.History;
using FluentAssertions;
using Xunit;

namespace Mimic.DomainUnitTests.History;

public class TestHistory : History<int>
{
}

public class HistoryTest
{
    private readonly TestHistory _sut;
    private const int Tasks = 1;

    public HistoryTest()
    {
        _sut = new TestHistory();
    }

    [Fact]
    public void AddTasksCompletedInACycle_DoesNotThrow_WhenAddingACompletedTasks()
    {
        var action = () => _sut.Add(Tasks);
        action.Should().NotThrow();
    }
    
    [Fact]
    public void Value_ReturnsListOfAddedCompletedTasks_WhenTasksHaveBeenAdded()
    {
        _sut.Add(Tasks);
        var result = _sut.Value();
        result.Should().Equal(new List<int> { Tasks });
    }
}

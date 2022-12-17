using System.Collections.Generic;
using Domain.History;
using Domain.Tasks;
using FluentAssertions;
using Xunit;

namespace DomainUnitTests.History;

public class HistoryTest
{
    private readonly BurndownHistory _sut;
    private readonly CompletedTasks _completedTasks = new (1);

    public HistoryTest()
    {
        _sut = new BurndownHistory();
    }

    [Fact]
    public void AddTasksCompletedInACycle_DoesNotThrow_WhenAddingACompletedTasks()
    {
        var action = () => _sut.Add(_completedTasks);
        action.Should().NotThrow();
    }
    
    [Fact]
    public void Value_ReturnsListOfAddedCompletedTasks_WhenTasksHaveBeenAdded()
    {
        _sut.Add(_completedTasks);
        var result = _sut.Value();
        result.Should().Equal(new List<CompletedTasks> { _completedTasks });
    }
}

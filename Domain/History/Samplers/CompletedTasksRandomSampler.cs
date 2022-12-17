using Domain.Tasks;

namespace Domain.History.Samplers;

/// <summary>
/// A sampler that uses a team's history of completed tasks, selecting the number of completed tasks from a random cycle
/// </summary>
public class CompletedTasksRandomSampler : RandomSampler<CompletedTasks>
{
    /// <summary>
    /// CompletedTasksRandomSampler returns a randomly selected sample for a history of completed tasks
    /// </summary>
    /// <param name="history"></param>
    public CompletedTasksRandomSampler(IHistory<CompletedTasks> history) : base(history)
    {
    }
}

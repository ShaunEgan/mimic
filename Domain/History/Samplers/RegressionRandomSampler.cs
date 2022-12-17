using Domain.Tasks;

namespace Domain.History.Samplers;

/// <summary>
/// A sampler that uses a team's history of regressions, selecting the number of regressions from a random cycle
/// </summary>
public class RegressionRandomSampler : RandomSampler<AddedTasks>
{
    /// <summary>
    /// RegressionRandomSampler returns a randomly selected sample for a history of regressions
    /// </summary>
    /// <param name="history"></param>
    public RegressionRandomSampler(IHistory<AddedTasks> history) : base(history)
    {
    }
}

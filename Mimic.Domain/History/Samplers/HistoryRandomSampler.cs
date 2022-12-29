namespace Mimic.Domain.History.Samplers;

/// <summary>
/// A sampler that uses a team's history, randomly selecting an iterm from history
/// </summary>
public class HistoryRandomSampler : RandomSampler<Tasks>
{
    /// <summary>
    /// RegressionRandomSampler returns a randomly selected sample from the team's history
    /// </summary>
    /// <param name="history"></param>
    public HistoryRandomSampler(IHistory<Tasks> history) : base(history)
    {
    }
}

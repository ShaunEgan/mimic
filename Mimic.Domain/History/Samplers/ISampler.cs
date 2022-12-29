namespace Mimic.Domain.History.Samplers;

/// <summary>
/// ISampler concretions fetch samples based on a known history
/// </summary>
public interface ISampler<out T>
{
    /// <summary>
    /// Get the next sample from history
    /// </summary>
    /// <returns>The next sample</returns>
    public T NextSample();
}

namespace Domain.Abstractions;

/// <summary>
/// ISampler concretions fetch samples based on a known history
/// </summary>
public interface ISampler<out T>
{
    public T NextSample();
}

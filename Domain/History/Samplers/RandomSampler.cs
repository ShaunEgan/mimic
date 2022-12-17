using System;
using System.Linq;

namespace Domain.History.Samplers;

/// <summary>
/// Chooses a random sample from history. This will only return values which exist in history.
/// </summary>
/// <typeparam name="T"></typeparam>
public class RandomSampler<T> : ISampler<T>
{
    private readonly T[] _samples;
    private readonly Random _random;

    /// <summary>
    /// RandomSampler is able to return random samples from history
    /// </summary>
    /// <param name="history">The history to select samples from</param>
    protected RandomSampler(IHistory<T> history)
    {
        _samples = history.Value().ToArray();
        _random = new Random();
    }
    
    public T NextSample()
    {
        var index = _random.Next(0, _samples.Length);
        return _samples[index];
    }
}

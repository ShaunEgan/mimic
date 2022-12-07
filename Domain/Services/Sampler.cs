using System;
using System.Linq;
using Domain.Abstractions;
using Domain.ValueObjects;
using Domain.ValueObjects.History;

namespace Domain.Services;

/// <summary>
/// Chooses a random sample from history. This will only return values which exist in history.
/// </summary>
public class RandomHistoricalSampler : ISampler<CompletedTasks>
{
    private readonly CompletedTasks[] _samples;
    private readonly Random _random;

    /// <summary>
    /// RandomHistoricalSampler is able to return random samples from history
    /// </summary>
    /// <param name="history"></param>
    public RandomHistoricalSampler(History history)
    {
        _samples = history.Value().ToArray();
        _random = new Random();
    }

    /// <summary>
    /// Get next random sample from history
    /// </summary>
    /// <returns></returns>
    public CompletedTasks NextSample()
    {
        var index = _random.Next(0, _samples.Length);
        return _samples[index];
    }
}

using System;
using System.Linq;
using Domain.Abstractions;
using Domain.ValueObjects;

namespace Domain.Services;

public class RandomRegressionSampler : ISampler<AddedTasks>
{
    private readonly AddedTasks[] _samples;
    private readonly Random _random;

    public RandomRegressionSampler(RegressionHistory regressionHistory)
    {
        _samples = regressionHistory.Value().ToArray();
        _random = new Random();
    }

    public AddedTasks NextSample()
    {
        var index = _random.Next(0, _samples.Length);
        return _samples[index];
    }
}

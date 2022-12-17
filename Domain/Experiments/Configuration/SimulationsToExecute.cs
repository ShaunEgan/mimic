using System;
using Domain.Abstractions;

namespace Domain.Experiments.Configuration;

/// <summary>
/// The number of simulations to run for the experiment
/// </summary>
public class SimulationsToExecute : IValueObject<int>
{
    /// <summary>
    /// The number of simulations that the experiment must run
    /// </summary>
    private readonly uint _simulations;

    /// <summary>
    /// Specify the number of simulations to run for the experiment.
    /// 
    /// This number must be greater than 0.
    /// This number defaults to 10 000 simulations to execute.
    /// </summary>
    /// <param name="simulationsToExecute">The minimum number of simulations to execute</param>
    /// <exception cref="ArgumentException">Thrown when the number of iterations is not a positive integer greater than 0</exception>
    public SimulationsToExecute(int simulationsToExecute = 10000)
    {
        var simulationsToExecuteGreaterThanZero = simulationsToExecute > 0;
        if (!simulationsToExecuteGreaterThanZero)
        {
            throw new ArgumentException("Simulations must be a positive integer higher than 0");
        }

        _simulations = (uint)simulationsToExecute;
    }

    /// <summary>
    /// Get the number of simulations that the experiment should run
    /// </summary>
    /// <returns></returns>
    public int Value()
    {
        return (int)_simulations;
    }
}

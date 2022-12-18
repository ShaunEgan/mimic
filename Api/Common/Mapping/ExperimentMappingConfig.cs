using Application.Experiments.Commands.RunExperiment;
using Contracts.Experiments;
using Domain.Experiments;
using Mapster;

namespace Api.Common.Mapping;

public class ExperimentMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RunExperimentRequest, RunExperimentCommand>();

        config.NewConfig<ExperimentResults, RunExperimentResponse>()
            .Map(dest => dest.SimulationResults, src => src.Value().Select(x => x.Value()))
            .Map(dest => dest.ProbabilityBuckets, src => CalculateProbabilityBuckets(src));
    }

    private static int[] CalculateProbabilityBuckets(ExperimentResults experimentResults)
    {
        var simulationResults = experimentResults.Value().Select(x => x.Value()).ToArray();
        
        const int numberOfBuckets = 20;
        const int bucketSize = 100 / numberOfBuckets;

        var probabilityBuckets = new int[numberOfBuckets];

        for (var i = 0; i < numberOfBuckets; i++)
        {
            var probability = (i + 1) * bucketSize;
            var index = simulationResults.Length / 100 * probability - 1;

            probabilityBuckets[i] = simulationResults[index];
        }

        return probabilityBuckets;
    }
}

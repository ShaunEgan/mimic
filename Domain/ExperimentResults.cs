using System.Collections.Generic;

namespace Domain
{
    public class ExperimentResults
    {
        private readonly List<NumberOfCycles> _experimentResults = new List<NumberOfCycles>();

        public void AddSimulationResult(NumberOfCycles numberOfCycles)
        {
            _experimentResults.Add(numberOfCycles);
        }

        public IEnumerable<NumberOfCycles> GetExperimentResults()
        {
            return _experimentResults;
        }
    }
}

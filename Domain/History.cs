using System.Collections.Generic;

namespace Domain
{
    public class History
    {
        private readonly List<Record> _history = new List<Record>();

        public void AddRecord(Record record)
        {
            _history.Add(record);
        }

        public IEnumerable<Record> GetRecords()
        {
            return _history;
        }
    }
}

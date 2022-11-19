using System;

namespace Domain
{
    public class Backlog
    {
        private readonly uint _tasks;

        public Backlog(int tasks)
        {
            if (tasks < 0)
            {
                throw new ArgumentException("Backlog must be 0 or higher integer");
            }
            
            _tasks = (uint)tasks;
        }

        public int Value()
        {
            return (int)_tasks;
        }
    }
}

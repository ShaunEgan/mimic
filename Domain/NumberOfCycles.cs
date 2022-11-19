using System;

namespace Domain
{
    public class NumberOfCycles
    {
        private readonly uint _numberOfCyles;

        public NumberOfCycles(int numberOfCycles)
        {
            if (numberOfCycles < 1)
            {
                throw new ArgumentException("Number of cycles must be a positive integer");
            }

            _numberOfCyles = (uint)numberOfCycles;
        }

        public int Value()
        {
            return (int)_numberOfCyles;
        }
    }
}

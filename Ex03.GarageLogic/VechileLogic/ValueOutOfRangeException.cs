using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private readonly float r_MaxValueForRange;
        private readonly float r_MinValueForRange;

        public ValueOutOfRangeException(float i_MinValueForRange, float i_MaxValueForRange)
            : base(string.Format("The value recived is out of range it should be between {0} to {1}", i_MinValueForRange, i_MaxValueForRange))
        {
            r_MaxValueForRange = i_MaxValueForRange;
            r_MinValueForRange = i_MinValueForRange;
        }

        public float MaxValue
        {
            get { return r_MaxValueForRange; }
        }

        public float MinValue
        {
            get { return r_MinValueForRange; }
        }

    }
}

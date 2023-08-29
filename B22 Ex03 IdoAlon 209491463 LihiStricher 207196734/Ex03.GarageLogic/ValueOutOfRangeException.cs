using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public float MaxValue
        {
            get
            {
                return m_MaxValue;
            }
        }

        public float MinValue
        {
            get
            {
                return m_MinValue;
            }
        }

        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue)
            : base(string.Format("Note that the max value is {0} and the min value is {1}", i_MaxValue, i_MinValue))
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }
    }
}

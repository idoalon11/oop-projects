namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly float r_MaxAirPressureRecommended;
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;

        public Wheel(float i_MaxAirPressureRecommended)
        {
            r_MaxAirPressureRecommended = i_MaxAirPressureRecommended;
        }

        internal void Inflate(float i_AirrToAdd)
        {
            if (m_CurrentAirPressure + i_AirrToAdd > r_MaxAirPressureRecommended)
            {
                throw new ValueOutOfRangeException(MaxAirPressureRecommended, 0);
            }

            m_CurrentAirPressure += i_AirrToAdd;
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }

            set
            {
                m_CurrentAirPressure = value;
            }
        }

        public float MaxAirPressureRecommended
        {
            get
            {
                return r_MaxAirPressureRecommended;
            }
        }

        public string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
            }

            set
            {
                m_ManufacturerName = value;
            }
        }
    }
}

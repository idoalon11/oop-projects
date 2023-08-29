using System.Text;

namespace Ex03.GarageLogic
{
    public enum eLicenceType
    {
        A = 1,
        A1,
        B1,
        BB,
    }

    internal abstract class Motocycle : Vehicle
    {
        private eLicenceType m_LicenseType;
        private int m_EngineVolume;

        public Motocycle()
        {
            NumberOfWheels = 2;
            SetWheels(31);
        }

        public eLicenceType LicenseType
        {
            get
            {
                return m_LicenseType;
            }

            set
            {
                m_LicenseType = value;
            }
        }

        public int EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }

            set
            {
                m_EngineVolume = value;
            }
        }

        public void SetNewVehicle(eLicenceType i_LicenceType, int i_EngineVolume)
        {
            this.LicenseType = i_LicenceType;
            this.EngineVolume = i_EngineVolume;
        }

        public override string ToString()
        {
            StringBuilder motocycleInformation = new StringBuilder();

            motocycleInformation.Append(base.ToString());
            motocycleInformation.AppendLine("License type: " + m_LicenseType);
            motocycleInformation.Append("Engine volume: " + m_EngineVolume);

            return motocycleInformation.ToString();
        }
    }
}

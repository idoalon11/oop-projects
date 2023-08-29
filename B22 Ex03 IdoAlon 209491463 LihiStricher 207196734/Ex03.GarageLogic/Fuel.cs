using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eFuelType
    {
        Soler = 1,
        Octane95,
        Octane96,
        Octane98,
    }

    internal class Fuel : EnergySource
    {
        private eFuelType m_FuelType;

        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }

            set
            {
                m_FuelType = value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly List<Wheel> r_Wheels = new List<Wheel>();
        private EnergySource m_EnergySourceType;
        private string m_ModelName;
        private string m_LicenseNumber;
        private int m_NumberOfWheels;

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }

            set
            {
                m_ModelName = value;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }

            set
            {
                m_LicenseNumber = value;
            }
        }

        public EnergySource EnergySourceType
        {
            get
            {
                return m_EnergySourceType;
            }

            set
            {
                m_EnergySourceType = value;
            }
        }

        public int NumberOfWheels
        {
            get
            {
                return m_NumberOfWheels;
            }

            set
            {
                m_NumberOfWheels = value;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return r_Wheels;
            }
        }

        internal void InflaitTires()
        {
            float currentAmount;
            float maxAmount;

            foreach (Wheel wheel in r_Wheels)
            {
                currentAmount = wheel.CurrentAirPressure;
                maxAmount = wheel.MaxAirPressureRecommended;
                wheel.Inflate(maxAmount - currentAmount);
            }
        }

        internal void SetWheels(float i_MaxAirPressure)
        {
            for (int i = 0; i < m_NumberOfWheels; i++)
            {
                Wheels.Add(new Wheel(i_MaxAirPressure));
            }
        }

        public override string ToString()
        {
            StringBuilder basicInformationForVehical = new StringBuilder();
            StringBuilder tiersInformation = new StringBuilder();

            basicInformationForVehical.AppendLine("License number: " + LicenseNumber);
            basicInformationForVehical.AppendLine("Model name: " + m_ModelName);
            tiersInformation.AppendLine("Wheels air pressure: " + Wheels[0].CurrentAirPressure);
            tiersInformation.AppendLine("Wheels manufacturer: " + Wheels[0].ManufacturerName);
            basicInformationForVehical.Append(tiersInformation.ToString());

            return basicInformationForVehical.ToString();
        }
    }
}

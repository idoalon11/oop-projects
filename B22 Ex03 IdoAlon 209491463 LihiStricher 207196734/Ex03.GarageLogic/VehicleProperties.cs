using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eVehicleStatus
    {
        InRepair = 1,
        Repaired,
        Payed,
    }

    public class VehicleProperties
    {
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private eVehicleStatus m_VehicleStatus;

        public string OwnerName
        {
            get
            {
                return m_OwnerName;
            }

            set
            {
                m_OwnerName = value;
            }
        }

        public string OwnerPhoneNumber
        {
            get
            {
                return m_OwnerPhoneNumber;
            }

            set
            {
                m_OwnerPhoneNumber = value;
            }
        }

        public eVehicleStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }

            set
            {
                m_VehicleStatus = value;
            }
        }

        public override string ToString()
        {
            StringBuilder propertiesInformation = new StringBuilder();

            propertiesInformation.AppendLine("Owner name: " + OwnerName);
            propertiesInformation.AppendLine("vehicle status : " + VehicleStatus.ToString());
            propertiesInformation.Append("Owner phone number: " + OwnerPhoneNumber);

            return propertiesInformation.ToString();
        }
    }
}

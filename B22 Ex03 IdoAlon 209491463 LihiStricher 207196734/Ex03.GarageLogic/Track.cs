using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public enum eContainsCooledCarge
    {
        Yes = 1,
        No,
    }

    internal abstract class Track : Vehicle
    {
        private eContainsCooledCarge m_ContainsCooledCargo;
        private float m_CargoTankVolume;

        public Track()
        {
            NumberOfWheels = 16;
            SetWheels(24);
        }

        public eContainsCooledCarge ContainsCooledCargo
        {
            get
            {
                return m_ContainsCooledCargo;
            }

            set
            {
                m_ContainsCooledCargo = value;
            }
        }

        public float CargoTankVolume
        {
            get
            {
                return m_CargoTankVolume;
            }

            set
            {
                m_CargoTankVolume = value;
            }
        }

        public void SetNewVehicle(eContainsCooledCarge i_IfContainsCooledCargo, float i_CargoTankVolume)
        {
            this.ContainsCooledCargo = i_IfContainsCooledCargo;
            this.CargoTankVolume = i_CargoTankVolume;
        }

        public override string ToString()
        {
            StringBuilder trackInformation = new StringBuilder();

            trackInformation.Append(base.ToString());
            trackInformation.AppendLine("Contains Cooled Cargo: " + ContainsCooledCargo);
            trackInformation.Append("Cargo tank volume: " + CargoTankVolume);

            return trackInformation.ToString();
        }
    }
}

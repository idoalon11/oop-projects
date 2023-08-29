using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eCarColors
    {
        Red = 1,
        White,
        Green,
        Blue,
    }

    public enum eNumberOfDoors
    {
        Two = 1,
        Three,
        Four,
        Five,
    }

    internal abstract class Car : Vehicle
    {
        private eCarColors m_Color;
        private eNumberOfDoors m_NumberOfDoors;

        public Car()
        {
            NumberOfWheels = 4;
            SetWheels(29);
        }

        public eCarColors Color
        {
            get
            {
                return m_Color;
            }

            set
            {
                m_Color = value;
            }
        }

        public eNumberOfDoors NumberOfDoors
        {
            get
            {
                return m_NumberOfDoors;
            }

            set
            {
                m_NumberOfDoors = value;
            }
        }

        public void SetNewVehicle(eCarColors i_Color, eNumberOfDoors i_NumberOfDoors)
        {
            this.Color = i_Color;
            this.NumberOfDoors = i_NumberOfDoors;
        }

        public override string ToString()
        {
            StringBuilder carInformation = new StringBuilder();

            carInformation.Append(base.ToString());
            carInformation.AppendLine("Numbers of doors: " + m_NumberOfDoors);
            carInformation.Append("Car color: " + m_Color);

            return carInformation.ToString();
        }
    }
}

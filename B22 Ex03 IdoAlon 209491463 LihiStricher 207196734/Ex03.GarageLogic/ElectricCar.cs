using System.Text;

namespace Ex03.GarageLogic
{
    internal class ElectricCar : Car
    {
        public ElectricCar()
        {
            this.EnergySourceType = new Electric();
            this.EnergySourceType.MaxAmount = 3.3f;
        }

        public override string ToString()
        {
            StringBuilder electricInfomation = new StringBuilder();

            electricInfomation.AppendLine(base.ToString());
            electricInfomation.Append("Remaning energy percentage (hours): " + this.EnergySourceType.RemainingEnergyPercentage + "%");

            return electricInfomation.ToString();
        }
    }
}

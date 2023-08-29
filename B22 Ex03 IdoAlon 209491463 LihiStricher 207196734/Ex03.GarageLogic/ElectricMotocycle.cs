using System.Text;

namespace Ex03.GarageLogic
{
    internal class ElectricMotocycle : Motocycle
    {
        public ElectricMotocycle()
        {
            this.EnergySourceType = new Electric();
            this.EnergySourceType.MaxAmount = 2.5f;
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

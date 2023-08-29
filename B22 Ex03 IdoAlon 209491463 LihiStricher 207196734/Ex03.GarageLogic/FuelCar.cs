using System.Text;

namespace Ex03.GarageLogic
{
    internal class FuelCar : Car
    {
        public FuelCar()
        {
            this.EnergySourceType = new Fuel();
            this.EnergySourceType.MaxAmount = 38f;
            (this.EnergySourceType as Fuel).FuelType = eFuelType.Octane95;
        }

        public override string ToString()
        {
            StringBuilder fuelInfomation = new StringBuilder();

            fuelInfomation.AppendLine(base.ToString());
            fuelInfomation.AppendLine("Fuel type: " + (this.EnergySourceType as Fuel).FuelType);
            fuelInfomation.Append("Remaning energy percentage: " + this.EnergySourceType.RemainingEnergyPercentage + "%");

            return fuelInfomation.ToString();
        }
    }
}

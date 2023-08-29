using System.Text;

namespace Ex03.GarageLogic
{
    internal class FuelMotocycle : Motocycle
    {
        public FuelMotocycle()
        {
            this.EnergySourceType = new Fuel();
            this.EnergySourceType.MaxAmount = 6.2f;
            (this.EnergySourceType as Fuel).FuelType = eFuelType.Octane98;
        }

        public override string ToString()
        {
            StringBuilder motoFuelInformation = new StringBuilder();

            motoFuelInformation.AppendLine(base.ToString());
            motoFuelInformation.AppendLine("Fuel type: " + (this.EnergySourceType as Fuel).FuelType);
            motoFuelInformation.Append("Remaning energy percentage: " + this.EnergySourceType.RemainingEnergyPercentage + "%");

            return motoFuelInformation.ToString();
        }
    }
}
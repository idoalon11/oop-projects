using System.Text;

namespace Ex03.GarageLogic
{
    internal class FuelTrack : Track
    {
        public FuelTrack()
        {
            this.EnergySourceType = new Fuel();
            this.EnergySourceType.MaxAmount = 120f;
            (this.EnergySourceType as Fuel).FuelType = eFuelType.Soler;
        }

        public override string ToString()
        {
            StringBuilder fuelTrackInformation = new StringBuilder();

            fuelTrackInformation.AppendLine(base.ToString());
            fuelTrackInformation.AppendLine("Fuel type: " + (this.EnergySourceType as Fuel).FuelType);
            fuelTrackInformation.Append("Remaning energy percentage: " + this.EnergySourceType.RemainingEnergyPercentage + "%");

            return fuelTrackInformation.ToString();
        }
    }
}

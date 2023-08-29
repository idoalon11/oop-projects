using System;

namespace Ex03.GarageLogic
{
    public enum eVehicleType
    {
        ElectricCar = 1,
        FuelCar,
        Track,
        ElectricMotocycle,
        FuelMotocycle,
    }

    public class Factory
    {
        public static IndividualVehicleInGarage CreateNewVehicle(eVehicleType i_VehicleType, string i_LicenseNumber)
        {
            IndividualVehicleInGarage individualVehicle;

            individualVehicle = Garage.FindIndividualVehicleInList(i_LicenseNumber);
            if (individualVehicle != null)
            {
                individualVehicle.Properties.VehicleStatus = eVehicleStatus.InRepair;
                throw new Exception("Your vehicle is already in our garage.");
            }
            else
            {
                if (i_VehicleType == eVehicleType.ElectricCar)
                {
                    individualVehicle = new IndividualVehicleInGarage(new ElectricCar());
                }
                else if (i_VehicleType == eVehicleType.FuelCar)
                {
                    individualVehicle = new IndividualVehicleInGarage(new FuelCar());
                }
                else if (i_VehicleType == eVehicleType.ElectricMotocycle)
                {
                    individualVehicle = new IndividualVehicleInGarage(new ElectricMotocycle());
                }
                else if (i_VehicleType == eVehicleType.FuelMotocycle)
                {
                    individualVehicle = new IndividualVehicleInGarage(new FuelMotocycle());
                }
                else if (i_VehicleType == eVehicleType.Track)
                {
                    individualVehicle = new IndividualVehicleInGarage(new FuelTrack());
                }

                individualVehicle.Properties.VehicleStatus = eVehicleStatus.InRepair;
                individualVehicle.RepairVehicle.LicenseNumber = i_LicenseNumber;

                return individualVehicle;
            }
        }
    }
}

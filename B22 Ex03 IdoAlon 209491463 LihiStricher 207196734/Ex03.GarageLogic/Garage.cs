using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Garage
    {
        private static readonly List<IndividualVehicleInGarage> sr_VehiclesInGarage = new List<IndividualVehicleInGarage>();

        public static List<IndividualVehicleInGarage> VehiclesInGarage
        {
            get
            {
                return sr_VehiclesInGarage;
            }
        }

        public static IndividualVehicleInGarage FindIndividualVehicleInList(string i_LicenseNumber)
        {
            IndividualVehicleInGarage serchedVehicle = null;

            foreach (IndividualVehicleInGarage vehicle in sr_VehiclesInGarage)
            {
                if (vehicle.RepairVehicle.LicenseNumber.Equals(i_LicenseNumber))
                {
                    serchedVehicle = vehicle;
                }
            }

            return serchedVehicle;
        }

        public static Vehicle FindVehicleInList(string i_LicenseNumber)
        {
            IndividualVehicleInGarage serchedIndividualVehicle = FindIndividualVehicleInList(i_LicenseNumber);
            Vehicle serchedVehicle = null;

            if(serchedIndividualVehicle != null)
            {
                serchedVehicle = serchedIndividualVehicle.RepairVehicle;
            }

            return serchedVehicle;
        }

        public static StringBuilder DisplayListOfVehiclesInTheGarage(string i_VehicleStatus)
        {
            StringBuilder listOfVehicales = new StringBuilder();
            eVehicleStatus vehicleStatus;

            if (!Enum.TryParse(i_VehicleStatus, out vehicleStatus))
            {
                throw new FormatException("Your input is invalid. This is not an option.");
            }
            else if (!Enum.IsDefined(typeof(eVehicleStatus), vehicleStatus))
            {
                throw new ArgumentException("Your input is invalid. This is not an option.");
            }

            foreach (IndividualVehicleInGarage vehicle in sr_VehiclesInGarage)
            {
                if (vehicle.Properties.VehicleStatus == vehicleStatus)
                {
                    listOfVehicales.AppendLine(vehicle.RepairVehicle.LicenseNumber);
                }
            }

            if(listOfVehicales.Length == 0)
            {
                listOfVehicales.AppendLine("There is no vehicles from this status in our garage");
            }

            return listOfVehicales;
        }

        public static void ChangeVehicleStatus(string i_LicenseNumber, string i_VehicleNewStatus)
        {
            eVehicleStatus vehicleNewStatus;
            IndividualVehicleInGarage individualVehicleToChangeStatus = FindIndividualVehicleInList(i_LicenseNumber);

            if (!Enum.TryParse(i_VehicleNewStatus, out vehicleNewStatus))
            {
                throw new ArgumentException("Your input is invalid. This is not an option.");
            }
            else if (!Enum.IsDefined(typeof(eVehicleStatus), vehicleNewStatus))
            {
                throw new ArgumentException("Your input is invalid. This is not an option.");
            }

            if (individualVehicleToChangeStatus == null)
            {
                throw new Exception("Sorry, this vehicle is not in our garage.");
            }
            else
            {
                individualVehicleToChangeStatus.Properties.VehicleStatus = vehicleNewStatus;
            }
        }

        public static void InflateTiresToMaximun(string i_LicenseNumber)
        {
            Vehicle vehicleToInflate = FindVehicleInList(i_LicenseNumber);

            if (vehicleToInflate == null)
            {
                throw new Exception("This vehicle is not in our garage");
            }
            else
            {
                vehicleToInflate.InflaitTires();
            }
        }

        public static void RefuelVehicle(string i_LicenseNumber, eFuelType i_FuelType, float i_Amount)
        {
            Vehicle vehicleToRefuel = FindVehicleInList(i_LicenseNumber);

            if (vehicleToRefuel == null)
            {
                throw new Exception("Sorry, the vehicle is not in our garage.");
            }
            else
            {
                if (vehicleToRefuel.EnergySourceType is Fuel)
                {
                    if ((vehicleToRefuel.EnergySourceType as Fuel).FuelType == i_FuelType)
                    {
                        vehicleToRefuel.EnergySourceType.FillEnergy(i_Amount);
                    }
                    else
                    {
                        throw new ArgumentException("You are trying to add a wrong type of fuel to your vehicle..");
                    }
                }
                else
                {
                    throw new FormatException("This vehicle does not have a fuel engine.");
                }
            }
        }

        public static void ChargeVehicle(string i_LicenseNumber, float i_MinutesToCharge)
        {
            Vehicle vehicleToCharge = FindVehicleInList(i_LicenseNumber);

            if (vehicleToCharge == null)
            {
                throw new Exception("Sorry, the vehicle is not in our garage.");
            }
            else
            {
                if (vehicleToCharge.EnergySourceType is Electric)
                {
                    vehicleToCharge.EnergySourceType.FillEnergy(i_MinutesToCharge);
                }
                else
                {
                    throw new FormatException("This vehicle does not have an electric engine.");
                }
            }
        }
    }
}
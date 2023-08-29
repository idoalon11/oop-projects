using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class Program
    {
        private static IndividualVehicleInGarage m_CurrentIndividualVehicle;
        private static Vehicle m_CurrentVehicle;
        private static bool m_UserWantToQuit;
        private static Dictionary<int, string> m_functionMenu;

        public static void Main()
        {
            garageManegment();
        }

        private static void garageManegment()
        {
            m_UserWantToQuit = false;

            createFunctionMenu();
            Console.WriteLine("Wellcome to our garage!");
            while (!m_UserWantToQuit)
            {
                printFunctionMenu();
                string userChoose = Console.ReadLine();
                Console.Clear();
                try
                {
                    runFunction(userChoose);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                if(!m_UserWantToQuit)
                {
                    Console.WriteLine("Do you want to continue? If yes, please press enter. Otherwise press Q");
                    if (Console.ReadLine() == "Q")
                    {
                        m_UserWantToQuit = true;
                    }

                    Console.Clear();
                }
            }
        }

        private static void createFunctionMenu()
        {
            m_functionMenu = new Dictionary<int, string>();
            m_functionMenu.Add(0, "Please press the number of the function you want to operate:");
            m_functionMenu.Add(1, "1)Insert vehicle to the garage");
            m_functionMenu.Add(2, "2)Display a list of the license currently in the garage");
            m_functionMenu.Add(3, "3)Change a certain vehicle's status");
            m_functionMenu.Add(4, "4)Inflate tires to maximum");
            m_functionMenu.Add(5, "5)Refuel");
            m_functionMenu.Add(6, "6)Charge");
            m_functionMenu.Add(7, "7)Display vehicle information");
            m_functionMenu.Add(8, "8)Exist the garage");
        }

        private static void printFunctionMenu()
        {
            foreach (KeyValuePair<int, string> function in m_functionMenu)
            {
                Console.WriteLine(function.Value);
            }
        }

        private static void runFunction(string i_UserChoise)
        {
            int userChoise;

            if (!int.TryParse(i_UserChoise, out userChoise))
            {
                throw new FormatException("Your input is invalid. You have to enter a number.");
            }
            else
            {
                switch (userChoise)
                {
                    case 1:
                        insertNewVehicle();
                        break;
                    case 2:
                        displayListOfLicense();
                        break;
                    case 3:
                        changeVehicleStatus();
                        break;
                    case 4:
                        inflateTires();
                        break;
                    case 5:
                        refuel();
                        break;
                    case 6:
                        charge();
                        break;
                    case 7:
                        displayVehicleInformation();
                        break;
                    case 8:
                        m_UserWantToQuit = true;
                        break;
                    default:
                        throw new ArgumentException("You entered an invalid unput.");
                }
            }
        }

        private static void insertNewVehicle()
        {
            eVehicleType vehicleType;
            string userInput;
            string inputLicenseNumber;

            Console.WriteLine("Please choose one of the following option:");
            printEnum(typeof(eVehicleType));
            userInput = Console.ReadLine();
            if (!Enum.TryParse(userInput, out vehicleType))
            {
                throw new FormatException("Your input is invalid. This is not an option.");
            }
            else if (!Enum.IsDefined(typeof(eVehicleType), vehicleType))
            {
                throw new ArgumentException("Your input is invalid. This is not an option.");
            }

            Console.WriteLine("Please enter the license number of your vehicle:");
            inputLicenseNumber = Console.ReadLine();
            m_CurrentIndividualVehicle = Factory.CreateNewVehicle(vehicleType, inputLicenseNumber);
            m_CurrentVehicle = m_CurrentIndividualVehicle.RepairVehicle;
            initOwnerDetails();
            initBasicProperties();
            initOtherProperties();
            Garage.VehiclesInGarage.Add(m_CurrentIndividualVehicle);
        }

        private static void printEnum(Type i_TypeOfEnumToPrint)
        {
            string[] enumNames = Enum.GetNames(i_TypeOfEnumToPrint);

            for (int i = 1; i <= enumNames.Length; i++)
            {
                Console.WriteLine(i + ")" + enumNames[i - 1]);
            }
        }

        private static void initBasicProperties()
        {
            float remainingEnergy;
            string userInput;
            float currentVehicleMaxAmount = m_CurrentVehicle.EnergySourceType.MaxAmount;

            Console.WriteLine("Please enter a model name:");
            m_CurrentVehicle.ModelName = Console.ReadLine();
            if (!consistOnlyNumbersOrLetters(m_CurrentVehicle.ModelName))
            {
                throw new ArgumentException("Model name must be consist of only numbers or letters");
            }

            Console.WriteLine("Please eneter remaining energy:");
            userInput = Console.ReadLine();
            if (!float.TryParse(userInput, out remainingEnergy))
            {
                throw new FormatException("This is not a float! consider check what is float in google and come back");
            }
            else if (remainingEnergy > currentVehicleMaxAmount || remainingEnergy < 0)
            {
                throw new ValueOutOfRangeException(currentVehicleMaxAmount, 0);
            }

            m_CurrentVehicle.EnergySourceType.RemainingEnergyPercentage = remainingEnergy / currentVehicleMaxAmount * 100;
            initWheels();
        }

        private static void initOtherProperties()
        {
            Type typeOfCurrentVehicle = m_CurrentVehicle.GetType();
            string messageToUser;
            string userInput;
            int userChoiseOfEnum;

            ParameterInfo[] parameters = typeOfCurrentVehicle.GetMethod("SetNewVehicle").GetParameters();
            object[] parametersToSend = new object[parameters.Length];
            int i = 0;
            foreach (ParameterInfo param in parameters)
            {
                messageToUser = paramToString(param.Name);
                Console.WriteLine("Please enter " + messageToUser);
                if (param.ParameterType.IsEnum)
                {
                    printEnum(param.ParameterType);
                    userInput = Console.ReadLine();
                    if (!Enum.IsDefined(param.ParameterType, userInput))
                    {
                        if (!int.TryParse(userInput, out userChoiseOfEnum))
                        {
                            throw new FormatException("Your input is invalid. your vehicle is not insert to our garage.");
                        }
                        else if (!Enum.IsDefined(param.ParameterType, userChoiseOfEnum))
                        {
                            throw new ArgumentException("Your input is invalid. your vehicle is not insert to our garage.");
                        }
                    }

                    parametersToSend[i] = Enum.Parse(param.ParameterType, userInput);
                }
                else
                {
                    try
                    {
                        userInput = Console.ReadLine();
                        parametersToSend[i] = Convert.ChangeType(userInput, param.ParameterType);
                    }
                    catch(Exception)
                    {
                        throw new ArgumentException("Your input is invalid. Your vehicle is not insert to our garage.");
                    }
                }

                i++;
            }

            typeOfCurrentVehicle.GetMethod("SetNewVehicle").Invoke(m_CurrentVehicle, parametersToSend);
        }

        private static string paramToString(string i_StringToSplit)
        {
            StringBuilder splitString = new StringBuilder();

            for (int i = 0; i < i_StringToSplit.Length; i++)
            {
                if (char.IsUpper(i_StringToSplit[i]))
                {
                    splitString.Append(' ');
                    splitString.Append(char.ToLower(i_StringToSplit[i]));
                }
                else
                {
                    splitString.Append(i_StringToSplit[i]);
                }
            }

            return splitString.ToString().Substring(3);
        }

        private static void initWheels()
        {
            float airPressure;
            string userInput;
            string manuFacturerName;

            Console.WriteLine("Please enter manufacturer of your wheels:");
            manuFacturerName = Console.ReadLine();
            Console.WriteLine("Please enter current air pressure of your wheels:");
            userInput = Console.ReadLine();
            if (!float.TryParse(userInput, out airPressure))
            {
                throw new FormatException("This is not a float! consider check what is float in google and come back.");
            }
            else if (airPressure > m_CurrentVehicle.Wheels[0].MaxAirPressureRecommended || airPressure < 0)
            {
                throw new ValueOutOfRangeException(m_CurrentVehicle.Wheels[0].MaxAirPressureRecommended, 0);
            }
            else
            {
                for (int j = 0; j < m_CurrentVehicle.NumberOfWheels; j++)
                {
                    m_CurrentVehicle.Wheels[j].ManufacturerName = manuFacturerName;
                    m_CurrentVehicle.Wheels[j].CurrentAirPressure = airPressure;
                }
            }
        }

        private static void initOwnerDetails()
        {
            string fullName;
            string phoneNumber;

            Console.WriteLine("Please enter your full name:");
            fullName = Console.ReadLine();
            if (!consistOnlyLetters(fullName))
            {
                throw new ArgumentException("The full name need to be consists of only letters");
            }

            Console.WriteLine("Please enter your phone number:");
            phoneNumber = Console.ReadLine();
            if (!consistOnlyNumbers(phoneNumber))
            {
                throw new ArgumentException("Phone number need to be consists of only numbers");
            }

            m_CurrentIndividualVehicle.Properties.OwnerName = fullName;
            m_CurrentIndividualVehicle.Properties.OwnerPhoneNumber = phoneNumber;
        }

        private static void displayListOfLicense()
        {
            StringBuilder listOfLicense;
            string userInput;

            Console.WriteLine("Please choose filtering option based on status");
            printEnum(typeof(eVehicleStatus));
            userInput = Console.ReadLine();
            listOfLicense = Garage.DisplayListOfVehiclesInTheGarage(userInput);
            Console.WriteLine(listOfLicense.ToString());
        }

        private static void changeVehicleStatus()
        {
            string inputLicenseNumber;
            string desiredStatus;

            Console.WriteLine("Please enter license number:");
            inputLicenseNumber = Console.ReadLine();
            Console.WriteLine("Please enter new desired status:");
            printEnum(typeof(eVehicleStatus));
            desiredStatus = Console.ReadLine();
            Garage.ChangeVehicleStatus(inputLicenseNumber, desiredStatus);
            Console.WriteLine("Desired status has been updated.");
        }

        private static void inflateTires()
        {
            string inputLicenseNumber;

            Console.WriteLine("Please enter a license number");
            inputLicenseNumber = Console.ReadLine();
            Garage.InflateTiresToMaximun(inputLicenseNumber);
            Console.WriteLine("Your tiers are ready to go!");
        }

        private static void refuel()
        {
            eFuelType fuelType;
            float amountToFill;
            string inputLicenseNumber;
            string userInput;

            Console.WriteLine("Please enter a license number");
            inputLicenseNumber = Console.ReadLine();
            Console.WriteLine("Please eneter fuel type");
            printEnum(typeof(eFuelType));
            userInput = Console.ReadLine();
            if (!Enum.TryParse(userInput, out fuelType))
            {
                throw new FormatException("Your input is invalid. This is not an option.");
            }
            else if (!Enum.IsDefined(typeof(eFuelType), fuelType))
            {
                throw new ArgumentException("Your input is invalid. This is not an option.");
            }

            Console.WriteLine("Please enter amount to fill");
            userInput = Console.ReadLine();
            if (!float.TryParse(userInput, out amountToFill))
            {
                throw new FormatException("This is not a valid amout of fuel, are you sure that you know what is fuel?");
            }

            Garage.RefuelVehicle(inputLicenseNumber, fuelType, amountToFill);
            Console.WriteLine("That's it! Your car is ready to go");
        }

        private static void charge()
        {
            float minutesToCharge;
            string userInput;
            string inputLicenseNumber;

            Console.WriteLine("Please enter a license number");
            inputLicenseNumber = Console.ReadLine();
            Console.WriteLine("Please enter amount of minutes that you want to charge");
            userInput = Console.ReadLine();
            if (!float.TryParse(userInput, out minutesToCharge))
            {
                throw new FormatException("This is not a valid time of hours to charge.");
            }

            Garage.ChargeVehicle(inputLicenseNumber, minutesToCharge / 60);
            Console.WriteLine("That's it! Your car is ready to go");
        }

        private static void displayVehicleInformation()
        {
            string inputLicenseNumber;

            Console.WriteLine("Please enter license number:");
            inputLicenseNumber = Console.ReadLine();
            m_CurrentIndividualVehicle = Garage.FindIndividualVehicleInList(inputLicenseNumber);
            if (m_CurrentIndividualVehicle == null)
            {
                throw new Exception("There is no vehicle with this license number in our garage.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine(m_CurrentIndividualVehicle.Properties.ToString());
                Console.WriteLine(m_CurrentIndividualVehicle.RepairVehicle.ToString());
            }
        }

        private static bool consistOnlyLetters(string i_StringToCheck)
        {
            bool consistOnlyLetters = true;

            for (int i = 0; i < i_StringToCheck.Length; i++)
            {
                if (!char.IsLetter(i_StringToCheck[i]) && !char.IsWhiteSpace(i_StringToCheck[i]))
                {
                    consistOnlyLetters = false;
                }
            }

            return consistOnlyLetters;
        }

        private static bool consistOnlyNumbers(string i_NumberToCheck)
        {
            bool consistOnlyNumbers = true;

            for (int i = 0; i < i_NumberToCheck.Length; i++)
            {
                if (!char.IsDigit(i_NumberToCheck[i]))
                {
                    consistOnlyNumbers = false;
                }
            }

            return consistOnlyNumbers;
        }

        private static bool consistOnlyNumbersOrLetters(string i_StringToCheck)
        {
            bool consistOnlyNumbersOrLetters = true;

            for (int i = 0; i < i_StringToCheck.Length; i++)
            {
                if (!char.IsLetterOrDigit(i_StringToCheck[i]))
                {
                    consistOnlyNumbersOrLetters = false;
                }
            }

            return consistOnlyNumbersOrLetters;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConcoleUI
{
	class Menu
	{
		private readonly Garage r_Garage;
		private readonly VehicleBuilder r_VehicleBuilder;
		private readonly GarageVehicleBuilder r_GarageVehicleBuilder;
		private readonly WheelBuilder r_WheelBuilder;

		public Menu()
		{
			r_Garage = new Garage();
			r_VehicleBuilder = new VehicleBuilder();
			r_GarageVehicleBuilder = new GarageVehicleBuilder();
			r_WheelBuilder = new WheelBuilder();
		}

		public void MenuScreen()
		{
			eMenu userInput;
			string ShowMenu = string.Format(
	@"Welcome, please choose one of the options
1. Insert a new car to the garage
2. List of all the vehicles in the garage by license number
3. Change vehicle status 
4. pump vehicle's tires
5. refuel a gasoline vehicle 
6. charge an battery electric vehicle 
7. View full vehicle information 
8. exit program ");

			Console.WriteLine(ShowMenu);
			Enum.TryParse(Console.ReadLine(), out userInput);

			switch (userInput)
			{
				case eMenu.InsertVehicle:
					{
						String userInputForLicenseNumber = getLicenseNumber();
						if (!r_Garage.IsVehicleInGarage(userInputForLicenseNumber))
						{
							getVehicleType();
							getVehicleModel();
							getVehicleOwenerName();
							getVehicleOwenerPhoneNumber();
							r_VehicleBuilder.LicenseNumber = userInputForLicenseNumber;
							r_GarageVehicleBuilder.Vehicle = r_VehicleBuilder.CreateVehicle();
							r_Garage.AddVehicleToGarage(r_GarageVehicleBuilder.CreateVehicleGarage());
							Console.Clear();
							Console.WriteLine("The vehicle was successfully put into the garage" + Environment.NewLine);
							messageToUser();
						}
						else
						{
							Console.WriteLine("Vehicle in Garage. Changing status to repair" + Environment.NewLine);
							r_Garage.ChangeVehicleStatus(userInputForLicenseNumber, eStatus.Repair);
							messageToUser();
						}
						
					}
					break;
				case eMenu.DisplayLicenseNumbers:
					{
						displayVehiclesInGarage();
					}
					break;
				case eMenu.ChangeStatus:
					{
						changeVehicleStatus(getLicenseNumber());
						Console.WriteLine("The status has chanced correrctly");
						messageToUser();
					}
					break;
				case eMenu.PumpWheel:
					{
						pumpWheelsInVehicle();
						Console.WriteLine("The tires were successfully filled to the maximum");
						messageToUser();
					}
					break;
				case eMenu.Refuel:
					{
						String userInputForLicenseNumber = getLicenseNumber();
						refuelVehicle(userInputForLicenseNumber);
					}
					break;
				case eMenu.charge:
					{
						chargeVehicle();
					}
					break;
				case eMenu.DisplayInfo:
					{
						String userInputForLicenseNumber = getLicenseNumber();
						if (r_Garage.IsVehicleInGarage(userInputForLicenseNumber))
						{
							displayInfoSpecificLicenseNumber(userInputForLicenseNumber);
							messageToUser();
						}
					}
					break;
				case eMenu.Quit:
                    {
						Environment.Exit(0);
					}
					break;
			}

			Console.Clear();
			MenuScreen();
		}

		private static void messageToUser()
		{
			Console.WriteLine("Press any key to go back to menu...");
			Console.ReadLine();
		}

		private int getIntValidateAndInput(int i_MinOfRange, int i_MaxOfRange)
		{
			int ParseResult;
			string userInput;

			do
			{
				userInput = Console.ReadLine();
				while (!int.TryParse(userInput, out ParseResult))
				{
					Console.WriteLine("Bad input. Please enter an integer.");
					userInput = Console.ReadLine();
				}

				if (ParseResult < i_MinOfRange || ParseResult > i_MaxOfRange)
				{
					Console.WriteLine("Input is out of range. Please enter an integer within the specified range.");
				}
			} while (ParseResult < i_MinOfRange || ParseResult > i_MaxOfRange);

			return ParseResult;
		}

		private float getFloatValidateAndInput(float i_MinOfRange, float i_MaxOfRange)
		{
			float ParseResult;
			string userInput;

			do
			{
				userInput = Console.ReadLine();
				while (!float.TryParse(userInput, out ParseResult))
				{
					Console.WriteLine("Bad input. Please enter a number.");
					userInput = Console.ReadLine();
				}

				if (ParseResult < i_MinOfRange || ParseResult > i_MaxOfRange)
				{
					Console.WriteLine("Input is out of range. Please enter a number within the specified range.");
				}
			} while (ParseResult < i_MinOfRange || ParseResult > i_MaxOfRange);

			return ParseResult;
		}

		private void printData<T>()
		{
			int index = 0;
			StringBuilder textToPrint = new StringBuilder();

			foreach (string type in Enum.GetNames(typeof(T)))
			{
				textToPrint.AppendLine(string.Format("{0}. {1}", ++index, type));
			}

			Console.Write(textToPrint);
		}

		private String getLicenseNumber()
		{
			Console.Clear();
			Console.WriteLine("Please enter license number");
			String userInputForLicenseNumber = Console.ReadLine();

			try
			{

				GarageVehicleBuilder.CheckIfStringContainsOnlyDigits(userInputForLicenseNumber);
			}
			catch (Exception i_Exception)
			{
				Console.WriteLine(i_Exception.Message);
				getLicenseNumber();
			}

			return userInputForLicenseNumber;
		}

		private void changeVehicleStatus(string i_LicenseToChangeStatus)
		{
			Console.WriteLine("Enter status to change the vehicle to ");
			printData<eStatus>();
			eStatus statusToChangeTo = (eStatus)getIntValidateAndInput(1, 3);
			r_Garage.ChangeVehicleStatus(i_LicenseToChangeStatus, statusToChangeTo);
		}

		private void displayVehiclesInGarage()
        {
			string dataToPrint;
			Console.WriteLine("Do you wish to filter the vehicles by their status in the garage?");
			printData<eQuestion>();
			int userInputForFilter = getIntValidateAndInput(1, 2);
			eQuestion questionForTheCase;
			Enum.TryParse(userInputForFilter.ToString(), out questionForTheCase);

			switch (questionForTheCase)
            {
				case eQuestion.Yes:
                    {
						Console.WriteLine("Enter status to change the vehicle to ");
						printData<eStatus>();
						eStatus statusForFilter = (eStatus)getIntValidateAndInput(1, 3);
						dataToPrint = r_Garage.GetVehiclesLicensePlates(statusForFilter);
						printLicenseNumbers(dataToPrint);
					}
					break;
				case eQuestion.No:
                    {
						dataToPrint = r_Garage.GetVehiclesLicensePlates(null);
						printLicenseNumbers(dataToPrint);
					}
					break;
            }
		}

		private void printLicenseNumbers(String i_dataToPrint)
        {
			Console.WriteLine("The license numbers of the vehicles in the garage:");
			Console.WriteLine(i_dataToPrint);
			messageToUser();
		}

		private void getVehicleType()
		{
			int userVehicleType;
			Console.WriteLine("Please select your type of vehicle: ");
			printData<eVehicle>();
			userVehicleType = getIntValidateAndInput(1, 3);
			eVehicle vehicleToChoose;
			Enum.TryParse(userVehicleType.ToString(), out vehicleToChoose);

			switch (vehicleToChoose)
			{
				case eVehicle.Car:
					{
						getNumbersOfDoors();
						getColor();
						r_VehicleBuilder.setVehicleToCar();
						getEnergySourceDetails();
						getWheelsInformation(r_WheelBuilder.NumberOfWheelsForCar, r_WheelBuilder.CarWheelMaxAirPressure);
					}
					break;
				case eVehicle.Motorcycle:
					{
						getLicenseType();
						getEngineSize();
						r_VehicleBuilder.setVehicleToMotorcycle();
						getEnergySourceDetails();
						getWheelsInformation(r_WheelBuilder.NumberOfWheelsForMotorcycle, r_WheelBuilder.MotorcycleWheelMaxAirPressure);
					}
					break;
				case eVehicle.Truck:
					{
						getHazaredTransferingInformation();
						getCargoSize();
						r_VehicleBuilder.setVehicleToTruck();
						r_VehicleBuilder.setVehicleToGasoline();
						getFuelTankInfo();
						getWheelsInformation(r_WheelBuilder.NumberOfWheelsForTruck, r_WheelBuilder.TruckWheelMaxAirPressure);
					}
					break;
			}
		}

		private void getWheelsInformation(int i_NumberOfWheels, float i_MaxAirPressure)
		{
			Console.WriteLine("Are all the wheels the same?");
			printData<eQuestion>();
			int userInputAllTheWheels = getIntValidateAndInput(1, 2);
			List<Wheel> wheel = new List<Wheel>(i_NumberOfWheels);
			r_WheelBuilder.MaxWheelpressure = i_MaxAirPressure;
			eQuestion questionForTheCase;
			Enum.TryParse(userInputAllTheWheels.ToString(), out questionForTheCase);

			switch (questionForTheCase)
			{
				case eQuestion.Yes:
					{
						Console.WriteLine("supply information for all wheels");
						Console.WriteLine("Please enter manufacturer name for all the wheels");
						getManufacturerName();
						Console.WriteLine("Please enter tire preesure for all the wheels");
						getTirePreesure();
						for (int i = 1; i <= i_NumberOfWheels; i++)
						{
							wheel.Add(r_WheelBuilder.CreateWheel());

						}
					}
					break;
				case eQuestion.No:
					{
						for (int i = 1; i <= i_NumberOfWheels; i++)
						{
							Console.WriteLine("supply information for wheel number " + i);
							Console.WriteLine("Please enter manufacturer name for wheel number " + i + ":");
							getManufacturerName();
							Console.WriteLine("Please enter tire preesure for wheel number " + i + ":");
							getTirePreesure();
							wheel.Add(r_WheelBuilder.CreateWheel());
						}
					}
					break;
			}

			r_VehicleBuilder.Wheels = wheel;
		}

		private void getManufacturerName()
		{
			try
			{
				r_WheelBuilder.ManufacturerName = Console.ReadLine();
			}
			catch (Exception i_Exception)
			{
				Console.WriteLine(i_Exception.Message);
				getManufacturerName();
			}
		}

		private void getTirePreesure()
		{
			try
			{
				r_WheelBuilder.TirePressure = getFloatValidateAndInput(0 ,r_WheelBuilder.MaxWheelpressure);
			}
			catch (Exception i_Exception)
			{
				Console.WriteLine(i_Exception.Message);
				getTirePreesure();
			}
		}

		private void getVehicleModel()
		{
			Console.Write("Please enter Model name: ");

			try
			{
				r_VehicleBuilder.ModelName = Console.ReadLine();
			}
			catch (Exception i_Exception)
			{
				Console.WriteLine(i_Exception.Message);
				getVehicleModel();
			}
		}

		private void getVehicleOwenerName()
		{
			Console.Write("Please enter owner name: ");

			try
			{
				r_GarageVehicleBuilder.OwnerName = Console.ReadLine();
			}
			catch (Exception i_Exception)
			{
				Console.WriteLine(i_Exception.Message);
				getVehicleOwenerName();
			}
		}
		private void getVehicleOwenerPhoneNumber()
		{
			Console.Write("Please enter owner Phone Number: ");

			try
			{
				r_GarageVehicleBuilder.OwnerPhone = Console.ReadLine();
			}
			catch (Exception i_Exception)
			{
				Console.WriteLine(i_Exception.Message);
				getVehicleOwenerPhoneNumber();
			}
		}

		private void getBatteryDetails()
		{
			Console.Write("Please enter battery time left in hours: ");
			float userInputForBattery;

			try
			{
				if (float.TryParse(Console.ReadLine(), out userInputForBattery))
				{
					r_VehicleBuilder.BatteryTimeLeft = userInputForBattery;
				}
				else
				{
					getBatteryDetails();
				}

			}
			catch (Exception i_Exception)
			{
				Console.WriteLine(i_Exception.Message);
				getBatteryDetails();
			}
		}

		private void getFuelTankInfo()
		{
			Console.Write("Please enter fuel left per liters: ");
			float userInputForFuel;

			try
			{
				if (float.TryParse(Console.ReadLine(), out userInputForFuel))
				{
					r_VehicleBuilder.GasVehicleCurrentFuelAmount = userInputForFuel;
				}
				else
				{
					getFuelTankInfo();
				}

			}
			catch (Exception i_Exception)
			{
				Console.WriteLine(i_Exception.Message);
				getFuelTankInfo();
			}
		}

		private void getNumbersOfDoors()
		{
			Console.WriteLine("Please enter how many doors you have in the car between 2-5");
			r_VehicleBuilder.DoorsAmount = (eNumbersOfDoors)getIntValidateAndInput(2, 5);
		}

		private void getColor()
		{
			Console.WriteLine("Please enter your car color");
			printData<eCarColor>();
			r_VehicleBuilder.Color = (eCarColor)getIntValidateAndInput(1, 4);

		}

		private void getLicenseType()
		{
			Console.WriteLine("Please enter your license type of your motorcycle");
			printData<eLicenseKind>();
			r_VehicleBuilder.LicenseType = (eLicenseKind)getIntValidateAndInput(1, 4);
		}

		private void getEngineSize()
		{
			Console.WriteLine("Please enter your engine size in CM3");
			int userInputForEngineSize;

			try
			{
				if (int.TryParse(Console.ReadLine(), out userInputForEngineSize))
				{
					r_VehicleBuilder.EngineVolume = userInputForEngineSize;
				}
				else
				{
					getEngineSize();
				}

			}
			catch (Exception i_Exception)
			{
				Console.WriteLine(i_Exception.Message);
				getEngineSize();
			}
		}

		private void getHazaredTransferingInformation()
		{
			Console.WriteLine("Is transfering hazarads?");
			printData<eQuestion>();
			int inputFromTheUser = getIntValidateAndInput(1, 2);
			eQuestion questionForTheCase;
			Enum.TryParse(inputFromTheUser.ToString(), out questionForTheCase);

			switch (questionForTheCase)
			{
				case eQuestion.Yes:
					{
						r_VehicleBuilder.IsTransferingHazard = true;
					}
					break;
				case eQuestion.No:
					{
						r_VehicleBuilder.IsTransferingHazard = false;
					}
					break;
			}
		}

		private void getCargoSize()
		{
			Console.WriteLine("Please enter truck cargo size");
			float userInputForCragoSize;

			try
			{
				if (float.TryParse(Console.ReadLine(), out userInputForCragoSize))
				{
					r_VehicleBuilder.CargoSize = userInputForCragoSize;
				}
				else
				{
					getCargoSize();
				}
			}
			catch (Exception i_Exception)
			{
				Console.WriteLine(i_Exception.Message);
				getCargoSize();
			}
		}

		private void displayInfoSpecificLicenseNumber(String i_LicenseNumber)
		{
			try
			{
				Console.WriteLine(r_Garage.getVehicleInformation(i_LicenseNumber));
			}
			catch (Exception i_Exception)
			{
				Console.WriteLine(i_Exception.Message);
			}
		}

		private void getEnergySourceDetails()
		{
			Console.WriteLine("Please select your energy source for the vehicle: ");
			printData<eEnergy>();
			int userEnergySourceForVehicle = getIntValidateAndInput(1, 2);
			eEnergy energyToChoose;
			Enum.TryParse(userEnergySourceForVehicle.ToString(), out energyToChoose);

			switch (energyToChoose)
			{
				case eEnergy.Gasoline:
					{
						getFuelTankInfo();
						r_VehicleBuilder.setVehicleToGasoline();
					}
					break;
				case eEnergy.electricity:
					{
						getBatteryDetails();
						r_VehicleBuilder.setVehicleToElectric();
					}
					break;
			}
		}

		private void refuelVehicle(String i_userInputForLicenseNumber)
        {
			Console.WriteLine("Enter amount of liters you want to refuel");
			float.TryParse(Console.ReadLine(), out float literToRefuel);
			Console.WriteLine("Enter fuel type of the vehicle ");
			printData<eFuel>();
			eFuel vehicleFuelType = (eFuel)getIntValidateAndInput(1, 4);

			try 
			{
				r_Garage.RefuelGasVehicle(i_userInputForLicenseNumber, literToRefuel, vehicleFuelType);
				Console.WriteLine("The refueling was completed successfully");
				messageToUser();
			}
			catch (Exception i_exception)
			{
				Console.WriteLine(i_exception.Message);
				messageToUser();
			}
		}

		private void chargeVehicle()
        {
			String userInputForLicenseNumber = getLicenseNumber();
			Console.WriteLine("Enter amount of hours to recharge the battery");
			float.TryParse(Console.ReadLine(), out float hoursToCharge); 

			try
			{ 
				r_Garage.RechargeBattery(userInputForLicenseNumber, hoursToCharge);
				Console.WriteLine("The chargeing was completed successfully");
				messageToUser();
			}
			catch (Exception i_exception)
			{
				Console.WriteLine(i_exception.Message);
				messageToUser();
			}
		}

		private void pumpWheelsInVehicle()
        {
			String userInputForLicenseNumber = getLicenseNumber();

			try 
			{ 
				r_Garage.PumpWheels(userInputForLicenseNumber); 
			}
			catch (Exception i_exception)
			{
				Console.WriteLine(i_exception.Message);
				pumpWheelsInVehicle();
			}
		}

	}
}



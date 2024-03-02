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
		public Garage m_Garage;
		public VehicleBuilder m_VehicleBuilder;
		public GarageVehicleBuilder m_GarageVehicleBuilder;
		public WheelBuilder m_WheelBuilder;

		public Menu()
		{
			m_Garage = new Garage();
			m_VehicleBuilder = new VehicleBuilder();
			m_GarageVehicleBuilder = new GarageVehicleBuilder();
			m_WheelBuilder = new WheelBuilder();
		}

		public void MenuScreen()
		{
			eMenu userInput;
			string ShowMenu = string.Format(
	@"Welcome, please choose one of the options
1. Insert a new car to the garage
2. List of all the vehicles in the garage by license number
3. Change vehicle status 
4. pump car's tires
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
						String userInputForLicenseNumber = GetLicenseNumber();
						if (!m_Garage.IsVehicleInGarage(userInputForLicenseNumber))
						{
							GetVehicleType();
							getVehicleModel();
							GetVehicleOwenerName();
							GetVehicleOwenerPhoneNumber();
							m_VehicleBuilder.LicenseNumber = userInputForLicenseNumber;
							m_GarageVehicleBuilder.Vehicle = m_VehicleBuilder.CreateVehicle();
							m_Garage.AddVehicleToGarage(m_GarageVehicleBuilder.CreateVehicleGarage());
						}
						else
						{
							Console.WriteLine("Vehicle in Garage. Changing status to repair");
							m_Garage.ChangeVehicleStatus(userInputForLicenseNumber, eStatus.Repair);
						}
					}
					break;
				case eMenu.DisplayLicenseNumbers:
					{
						DisplayVehiclesInGarage();
					}
					break;
				case eMenu.ChangeStatus:
					{
						ChangeVehicleStatus(GetLicenseNumber());
					}
					break;
				case eMenu.PumpWheel:
					{
						pumpWheelsInVehicle();
					}
					break;
				case eMenu.Refuel:
					{
						String userInputForLicenseNumber = GetLicenseNumber();
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
						String userInputForLicenseNumber = GetLicenseNumber();
						if (m_Garage.IsVehicleInGarage(userInputForLicenseNumber))
						{
							DisplayInfoSpecificLicenseNumber(userInputForLicenseNumber);
						}
					}
					break;
			}

			//Console.Clear();
			MenuScreen();
			Console.ReadLine();

		}

		public int GetIntValidateAndInput(int i_MinOfRange, int i_MaxOfRange)
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

		public float GetFloatValidateAndInput(float i_MinOfRange, float i_MaxOfRange)
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

		public String GetLicenseNumber()
		{
			Console.WriteLine("Please enter license number");
			String userInputForLicenseNumber = Console.ReadLine();
			try
			{

				GarageVehicleBuilder.CheckIfStringContainsOnlyDigits(userInputForLicenseNumber);
			}
			catch (Exception i_Exception)
			{
				Console.WriteLine(i_Exception.Message);
				GetLicenseNumber();
			}
			return userInputForLicenseNumber;
		}
		public void ChangeVehicleStatus(string LicenseToChangeStatus)
		{
			Console.WriteLine("Enter status to change the vehicle to ");
			printData<eStatus>();
			eStatus statusToChangeTo = (eStatus)GetIntValidateAndInput(1, 3);
			m_Garage.ChangeVehicleStatus(LicenseToChangeStatus, statusToChangeTo);
		}

		public void DisplayVehiclesInGarage()
        {
			string dataToPrint;
			Console.WriteLine("Do you wish to filter the vehicles by their status in the garage?");
			printData<eQuestion>();
			int userInputForFilter = GetIntValidateAndInput(1, 2);
			switch (userInputForFilter)
            {
				case 1:
                    {
						Console.WriteLine("Enter status to change the vehicle to ");
						printData<eStatus>();
						eStatus statusForFilter = (eStatus)GetIntValidateAndInput(1, 3);
						dataToPrint = m_Garage.GetVehiclesLicensePlates(statusForFilter);
						Console.WriteLine(dataToPrint);
					}
					break;
				case 2:
                    {
						dataToPrint = m_Garage.GetVehiclesLicensePlates(null);
						Console.WriteLine(dataToPrint);
					}
					break;

            }

		}

		public void GetVehicleType()
		{
			int userVehicleType;
			string userInput;
			Console.WriteLine("Please select your type of vehicle: ");
			printData<eVehicle>();
			userVehicleType = GetIntValidateAndInput(1, 3);

			switch (userVehicleType)
			{
				case 1:
					{
						getNumbersOfDoors();
						getColor();
						m_VehicleBuilder.setVehicleToCar();
						getEnergySourceDetails();
						getWheelsInformation(m_WheelBuilder.NumberOfWheelsForCar, m_WheelBuilder.CarWheelMaxAirPressure);
					}
					break;
				case 2:
					{
						getLicenseType();
						getEngineSize();
						m_VehicleBuilder.setVehicleToMotorcycle();
						getEnergySourceDetails();
						getWheelsInformation(m_WheelBuilder.NumberOfWheelsForMotorcycle, m_WheelBuilder.MotorcycleWheelMaxAirPressure);
					}
					break;
				case 3:
					{
						GatHazaredTransferingInformation();
						getCargoSize();
						m_VehicleBuilder.setVehicleToTruck();
						m_VehicleBuilder.setVehicleToGasoline();
						getFuelTankInfo();
						getWheelsInformation(m_WheelBuilder.NumberOfWheelsForTruck, m_WheelBuilder.TruckWheelMaxAirPressure);
					}
					break;
			}
		}

		private void getWheelsInformation(int i_NumberOfWheels, float i_MaxAirPressure)
		{
			Console.WriteLine("Are all the wheels the same?");
			printData<eQuestion>();
			int userInputAllTheWheels = GetIntValidateAndInput(1, 2);
			List<Wheel> wheel = new List<Wheel>(i_NumberOfWheels);
			m_WheelBuilder.MaxWheelpressure = i_MaxAirPressure;

			switch (userInputAllTheWheels)
			{
				case 1:
					{
						Console.WriteLine("supply information for all wheels");
						Console.WriteLine("Please enter manufacturer name for all the wheels");
						getManufacturerName();
						Console.WriteLine("Please enter tire preesure for all the wheels");
						getTirePreesure();
						for (int i = 1; i <= i_NumberOfWheels; i++)
						{
							wheel.Add(m_WheelBuilder.CreateWheel());

						}
					}
					break;
				case 2:
					{
						for (int i = 1; i <= i_NumberOfWheels; i++)
						{
							Console.WriteLine("supply information for wheel number " + i);
							Console.WriteLine("Please enter manufacturer name for wheel number " + i + ":");
							getManufacturerName();
							Console.WriteLine("Please enter tire preesure for wheel number " + i + ":");
							getTirePreesure();
							wheel.Add(m_WheelBuilder.CreateWheel());
						}
					}
					break;
			}
			m_VehicleBuilder.Wheels = wheel;
		}

		private void getManufacturerName()
		{
			try
			{
				m_WheelBuilder.ManufacturerName = Console.ReadLine();
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
				m_WheelBuilder.TirePressure = GetFloatValidateAndInput(0 ,m_WheelBuilder.MaxWheelpressure);
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
				m_VehicleBuilder.ModelName = Console.ReadLine();
			}
			catch (Exception i_Exception)
			{
				Console.WriteLine(i_Exception.Message);
				getVehicleModel();
			}
		}

		private void GetVehicleOwenerName()
		{
			Console.Write("Please enter owner name: ");
			try
			{
				m_GarageVehicleBuilder.OwnerName = Console.ReadLine();
			}
			catch (Exception i_Exception)
			{
				Console.WriteLine(i_Exception.Message);
				GetVehicleOwenerName();
			}
		}
		private void GetVehicleOwenerPhoneNumber()
		{
			Console.Write("Please enter owner Phone Number: ");
			try
			{
				m_GarageVehicleBuilder.OwnerPhone = Console.ReadLine();
			}
			catch (Exception i_Exception)
			{
				Console.WriteLine(i_Exception.Message);
				GetVehicleOwenerPhoneNumber();
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
					m_VehicleBuilder.BatteryTimeLeft = userInputForBattery;
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
					m_VehicleBuilder.GasVehicleCurrentFuelAmount = userInputForFuel;
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
			m_VehicleBuilder.DoorsAmount = (eNumbersOfDoors)GetIntValidateAndInput(2, 5);
		}

		private void getColor()
		{
			Console.WriteLine("Please enter your car color");
			printData<eCarColor>();
			m_VehicleBuilder.Color = (eCarColor)GetIntValidateAndInput(1, 4);

		}

		private void getLicenseType()
		{
			Console.WriteLine("Please enter your license type of your motorcycle");
			printData<eLicenseKind>();
			m_VehicleBuilder.LicenseType = (eLicenseKind)GetIntValidateAndInput(1, 4);
		}

		private void getEngineSize()
		{
			Console.WriteLine("Please enter your engine size in CM3");

			int userInputForEngineSize;
			try
			{
				if (int.TryParse(Console.ReadLine(), out userInputForEngineSize))
				{
					m_VehicleBuilder.EngineVolume = userInputForEngineSize;
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

		private void GatHazaredTransferingInformation()
		{
			String message = string.Format(@"Is transfering hazarads?
1.yes
2.no");
			Console.WriteLine(message);
			int inputFromTheUser = GetIntValidateAndInput(1, 2);

			switch (inputFromTheUser)
			{
				case 1:
					{
						m_VehicleBuilder.IsTransferingHazard = true;
					}
					break;
				case 2:
					{
						m_VehicleBuilder.IsTransferingHazard = false;
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
					m_VehicleBuilder.CargoSize = userInputForCragoSize;
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

		private void DisplayInfoSpecificLicenseNumber(String i_LicenseNumber)
		{
			try
			{
				Console.WriteLine(m_Garage.getVehicleInformation(i_LicenseNumber));
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
			int userEnergySourceForVehicle = GetIntValidateAndInput(1, 2);
			switch (userEnergySourceForVehicle)
			{
				case 1:
					{
						getFuelTankInfo();
						m_VehicleBuilder.setVehicleToGasoline();
					}
					break;
				case 2:
					{
						getBatteryDetails();
						m_VehicleBuilder.setVehicleToElectric();
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
			eFuel vehicleFuelType = (eFuel)GetIntValidateAndInput(1, 4);
			try { m_Garage.RefuelGasVehicle(i_userInputForLicenseNumber, literToRefuel, vehicleFuelType); }
			catch (Exception i_exception)
			{
				Console.WriteLine(i_exception.Message);
				refuelVehicle(i_userInputForLicenseNumber);
			}
		}

		private void chargeVehicle()
        {
			String userInputForLicenseNumber = GetLicenseNumber();
			Console.WriteLine("Enter amount of hours to recharge the battery");
			float.TryParse(Console.ReadLine(), out float hoursToCharge); ;
			try { m_Garage.RechargeBattery(userInputForLicenseNumber, hoursToCharge); }
			catch (Exception i_exception)
			{
				Console.WriteLine(i_exception.Message);
				chargeVehicle();
			}
		}

		private void pumpWheelsInVehicle()
        {
			String userInputForLicenseNumber = GetLicenseNumber();
			try { m_Garage.PumpWheels(userInputForLicenseNumber); }
			catch (Exception i_exception)
			{
				Console.WriteLine(i_exception.Message);
				pumpWheelsInVehicle();
			}
		}

	}
}



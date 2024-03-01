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

		public Menu()
		{
			m_Garage = new Garage();
			m_VehicleBuilder = new VehicleBuilder();
			m_GarageVehicleBuilder = new GarageVehicleBuilder();
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
							GetVehicleModel();
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
						//display licenseNumbers
					}
					break;
				case eMenu.ChangeStatus:
					{
						ChangeVehicleStatus(GetLicenseNumber());
					}
					break;
				case eMenu.PumpWheel:
					{
						
					}
					break;
				case eMenu.Refuel:
					{
						String userInputForLicenseNumber = GetLicenseNumber();
						Console.WriteLine("Enter amount of liters you want to refuel");
						float.TryParse(Console.ReadLine(), out float literToRefuel);
						Console.WriteLine("Enter fuel type of the vehicle ");
						printData<eFuel>();
						eFuel vehicleFuelType = (eFuel)GetValidateAndInput(1, 4);
						try { m_Garage.RefuelGasVehicle(userInputForLicenseNumber, literToRefuel, vehicleFuelType); }
						catch(Exception i_exception) {
							Console.WriteLine(i_exception.Message);
						}
					}
					
					break;
				case eMenu.charge:
					{
						String userInputForLicenseNumber = GetLicenseNumber();
						Console.WriteLine("Enter amount of hours to recharge the battery");
						float.TryParse(Console.ReadLine(), out float hoursToCharge); ;
						try { m_Garage.RechargeBattery(userInputForLicenseNumber, hoursToCharge); }
						catch (Exception i_exception)
						{
							Console.WriteLine(i_exception.Message);
						}
					}
					break;
				case eMenu.DisplayInfo:
					{
						String userInputForLicenseNumber = GetLicenseNumber();
						if (m_Garage.IsVehicleInGarage(userInputForLicenseNumber))
						{
							getDisplayInfo(userInputForLicenseNumber);
						}
					}
					break;
			}
		
			//Console.Clear();
			MenuScreen();
			Console.ReadLine();

		}

		public int GetValidateAndInput(int i_MinOfRange, int i_MaxOfRange)
		{
			String userInput = Console.ReadLine();
			int.TryParse(userInput, out int ParseResult);

			while (ParseResult > i_MaxOfRange || ParseResult < i_MinOfRange)
			{
				Console.WriteLine("bad parse put new input in range");
				userInput = Console.ReadLine();
				int.TryParse(userInput, out ParseResult);

			}
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
			eStatus statusToChangeTo = (eStatus)GetValidateAndInput(1,3);
			m_Garage.ChangeVehicleStatus(LicenseToChangeStatus, statusToChangeTo);
		}

		public void GetWheelsManufacurerName()
		{
		}

		public void GetVehicleType()
		{
			int userVehicleType;
			string userInput;
			Console.WriteLine("Please select your type of vehicle: ");
			printData<eVehicle>();
			userVehicleType = GetValidateAndInput(1, 3);

			switch (userVehicleType)
			{
				case 1:
					{
						getNumbersOfDoors();
						getColor();
						m_VehicleBuilder.setVehicleToCar();
						getEnergySourceDetails();
					}
					break;
				case 2:
					{
						getLicenseType();
						getEngineSize();
						m_VehicleBuilder.setVehicleToMotorcycle();
						getEnergySourceDetails();
					}
					break;
				case 3:
					{
						GatHazaredTransferingInformation();
						getCargoSize();
						m_VehicleBuilder.setVehicleToTruck();
						m_VehicleBuilder.setVehicleToGasoline();
		
						getFuelTankInfo();
					}
					break;
			}
		}

		public void GetVehicleModel()
		{
			Console.Write("Please enter Model name: ");
			try
			{
				m_VehicleBuilder.ModelName = Console.ReadLine();
			}
			catch (Exception i_Exception)
			{
				Console.WriteLine(i_Exception.Message);
				GetVehicleModel();
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
			m_VehicleBuilder.DoorsAmount = (eNumbersOfDoors)GetValidateAndInput(2, 5);
		}

		private void getColor()
		{
			Console.WriteLine("Please enter your car color");
			printData<eCarColor>();
			m_VehicleBuilder.Color = (eCarColor)GetValidateAndInput(1, 4);

		}

		private void getLicenseType()
		{
			Console.WriteLine("Please enter your license type of your motorcycle");
			printData<eLicenseKind>();
			m_VehicleBuilder.LicenseType = (eLicenseKind)GetValidateAndInput(1, 4);
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
			int inputFromTheUser = GetValidateAndInput(1, 2);

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

		private void getDisplayInfo(String i_LicenseNumber)
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
			int userEnergySourceForVehicle = GetValidateAndInput(1, 2);
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

	}
}



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
        }

        public void Main()
        {
            Garage garage = new Garage();
            eMenu userInput;
            string menu = string.Format(
    @"Welcome, please choose one of the options
1. Insert a new car to the garage
2. List of all the vehicles in the garage by license number
3. Change vehicle status 
4. pump car's tires
5. refuel a gasoline vehicle 
6. charge an battery electric vehicle 
7. View full vehicle information 
8. exit program ");

            Console.WriteLine(menu);
            Enum.TryParse(Console.ReadLine(), out userInput);
            switch (userInput)
            {
                case eMenu.InsertVehicle:
                    {
                        //optionOneInMenu(garage);
                        string userInputForLicenseNumber = Console.ReadLine();
                        
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
                            Console.WriteLine("Vehicl in Garage changing status to repair");
                            m_Garage.ChangeVehicleStatus(userInputForLicenseNumber,eStatus.Repair);
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

                    }
                    break;
                case eMenu.PumpWheel:
                    {
                        //pump
                    }
                    break;
                case eMenu.Refuel:
                    { }
                    break;
                case eMenu.charge:
                    { }
                    break;
                case eMenu.DisplayInfo:
                    { }
                    break;
            }
            // call menu again

            Console.ReadLine();


        }
        public int InputValidate(string i_Userinput, int i_MinOfRange, int i_MaxOfRange)
        {
            int.TryParse(i_Userinput, out int ParseResult);
            while (ParseResult > i_MaxOfRange || ParseResult < i_MinOfRange)
            {
                Console.WriteLine("bad parse put new input in range");
                i_Userinput = Console.ReadLine();
                int.TryParse(i_Userinput, out ParseResult);

            }
            return ParseResult;
        }

        public void GetVehicleType()
        {
            int userVehicleType;
            int userEnergySourceForVehicle;
            string userInput;
            Console.WriteLine("Please select your type of vehicle: ");
            userInput = Console.ReadLine();
            userVehicleType = InputValidate(userInput, 1, 3);

            switch (userVehicleType)
            {
                case 1:
                    {
                        m_VehicleBuilder.setVehicleToCar();
                    }
                    break;
                case 2:
                    {
                        m_VehicleBuilder.setVehicleToMotorcycle();
                    }
                    break;
                case 3:
                    {
                        m_VehicleBuilder.setVehicleToTruck();
                    }
                    break;
            }
            Console.WriteLine("Please select your energy source for the vehicle: ");
            userInput = Console.ReadLine();
            userEnergySourceForVehicle = InputValidate(userInput, 1, 2);
            switch (userEnergySourceForVehicle)
            {
                case 1:
                    {
                        m_VehicleBuilder.setVehicleToElectric();
                    }
                    break;
                case 2:
                    {
                        m_VehicleBuilder.setVehicleToGasoline();
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
            Console.Write("Please enter owner name: ");
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
    }
}



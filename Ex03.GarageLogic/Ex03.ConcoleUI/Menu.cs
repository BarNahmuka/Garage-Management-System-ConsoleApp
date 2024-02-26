using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VechileLogic;

namespace Ex03.ConcoleUI
{
    class Menu
    {
        public static void Main()
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
                        optionOneInMenu(garage);
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

        public static void optionOneInMenu(Garage i_garage)
        {
            Console.WriteLine("Please enter license number");
            string licenseNumber = Console.ReadLine();



            if (i_garage.IsVehicleInGarage(licenseNumber))
            {
                Console.WriteLine("The vehicle is already in the garage.");
                i_garage.ChangeVehicleStatus(licenseNumber, eStatus.Repair);
            }
            else
            {
                string optionForVehicle = string.Format(
                    @"Please choose vehicle type from the options
1.car
2.truck
3.motorcycle");
                Console.WriteLine(optionForVehicle);
                Enum.TryParse(Console.ReadLine(), out eVehicle userVehicleSelection);

                switch (userVehicleSelection)
                {
                    case eVehicle.Car:
                        {
                            string optionColor = string.Format(
     @"Please choose vehicle type from the options
1.Blue
2.White
3.Red
4.Yellow");
                            Console.WriteLine(optionColor);
                            Enum.TryParse(Console.ReadLine(), out eCarColor color);
                            Console.WriteLine("");

                            Console.WriteLine("Gasoline or electric?" + Environment.NewLine + "1.Gasoline" + Environment.NewLine + "2.Electric");
                            Enum.TryParse(Console.ReadLine(), out eEnergy energyType);
                            switch (energyType)
                            {
                                case eEnergy.electricity:
                                    {

                                    }
                                    break;
                                case eEnergy.Gasoline:
                                    {

                                    }
                                    break;
                            }
                        }
                        break;
                    case eVehicle.Motorcycle:
                        {
                            Console.WriteLine("Gasoline or electric?" + Environment.NewLine + "1.Gasoline" + Environment.NewLine + "2.Electric");
                            Enum.TryParse(Console.ReadLine(), out eEnergy energyType);
                            switch (energyType)
                            {
                                case eEnergy.electricity:
                                    {

                                    }
                                    break;
                                case eEnergy.Gasoline:
                                    {

                                    }
                                    break;
                            }
                        }
                        break;
                    case eVehicle.Truck:
                        {

                        }
                        break;

                }
            }
        }
    }
}


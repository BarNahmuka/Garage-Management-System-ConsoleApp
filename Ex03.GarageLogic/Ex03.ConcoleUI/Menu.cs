using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConcoleUI
{
    class Menu
    {
        public static void Main()
        {
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
            Enum.TryParse(Console.ReadLine(),out userInput);
            switch (userInput)
            {
                case eMenu.InsertVehicle:
                    {
                        //add vehicle to garage
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
    }
}

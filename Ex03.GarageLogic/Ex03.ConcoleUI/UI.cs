using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConcoleUI
{
    class UI
    {
        public static void Main()
        {
            string menu = string.Format(
    @"Welcome, please choose one of the options
1. Put a new car in the garage
2. Show the list of license numbers of the vehicles in the garage
3. Change vehicle mode
4. To inflate the tires of a car to the maximum
5. refuel a fuel driven vehicle
6. charge an electric vehicle 
7. View full vehicle information 
8. exit program ");

            Console.WriteLine(menu);
            //int num = Console.Read();


            try
            {
                int userInput = Console.Read();
                //int number = int.Parse(userInput);
                Console.WriteLine("good", 1 - 8);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();

        }
    }
}

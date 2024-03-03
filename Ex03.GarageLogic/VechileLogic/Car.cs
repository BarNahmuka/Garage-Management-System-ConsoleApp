using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Car
    {
        private readonly eCarColor r_Color;
        private readonly eNumbersOfDoors r_NumbersOfDoors;

        public Car(eCarColor i_Color, eNumbersOfDoors i_NumbersOfDoors)
        {
            r_Color = i_Color;
            r_NumbersOfDoors = i_NumbersOfDoors;
        }

        public eCarColor Color
        {
            get { return r_Color; }
        }

        public eNumbersOfDoors NumbersOfDoors
        {
            get { return r_NumbersOfDoors; }
        }

        public override string ToString()
        {
            return string.Format(
                @"Numbers of doors: {1}
Color: {2}",
                base.ToString(),
                r_NumbersOfDoors,
                r_Color);
        }
    }
}

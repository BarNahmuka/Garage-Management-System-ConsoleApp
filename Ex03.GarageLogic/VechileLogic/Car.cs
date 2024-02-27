using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Car
    {
        private eCarColor m_Color;
        private eNumbersOfDoors m_NumbersOfDoors;

        public Car(eCarColor i_Color, eNumbersOfDoors i_NumbersOfDoors)
        {
            m_Color = i_Color;
            m_NumbersOfDoors = i_NumbersOfDoors;
        }

        public eCarColor Color
        {
            get { return m_Color; }
        }

        public eNumbersOfDoors NumbersOfDoors
        {
            get { return m_NumbersOfDoors; }
        }
    }
}

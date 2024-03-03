using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public sealed class GarageVehicleBuilder
    {
        private string m_OwnerName;
        private string m_OwnerPhone;
        private Vehicle m_Vehicle;

        private static void isEmptyOrNullString(string i_String)
        {
            if (string.IsNullOrEmpty(i_String))
            {
                throw new NullReferenceException("The string cannot be empty");
            }
        }

        public static void CheckIfStringContainsOnlyLetters(string i_StringToCheck)
        {
            isEmptyOrNullString(i_StringToCheck);

            foreach (char character in i_StringToCheck)
            {
                if (!char.IsLetter(character))
                {
                    throw new FormatException("String must contain only letters.");
                }
            }
        }

        public GarageVehicle CreateVehicleGarage()
        {
            return new GarageVehicle(m_OwnerName, m_OwnerPhone, m_Vehicle);
        }

        public static void CheckIfStringContainsOnlyDigits(string i_StringToCheck)
        {
            isEmptyOrNullString(i_StringToCheck);

            foreach (char character in i_StringToCheck)
            {
                if (!char.IsDigit(character))
                {
                    throw new FormatException("Must contain only digits");
                }
            }
        }

        public string OwnerName
        {
            get { return m_OwnerName; }
            set
            {
                CheckIfStringContainsOnlyLetters(value);
                m_OwnerName = value;
            }
        }

        public string OwnerPhone
        {
            get { return m_OwnerPhone; }
            set
            {
                CheckIfStringContainsOnlyDigits(value);
                m_OwnerPhone = value;
            }
        }

        public Vehicle Vehicle
        {
            get { return m_Vehicle; }
            set { m_Vehicle = value; }
        }
    }
}

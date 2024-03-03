using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageVehicle
    {
        private readonly Vehicle r_Vehicle;
        private readonly string r_OwnerName;
        private readonly string r_OwnerPhone;
        private eStatus m_Status;

        public GarageVehicle(string i_OwnerName, string i_OwnerPhone, Vehicle i_Vehicle)
        {
            r_Vehicle = i_Vehicle;
            r_OwnerName = i_OwnerName;
            r_OwnerPhone = i_OwnerPhone;
            m_Status = eStatus.Repair;
        }
        public string OwnerName
        {
            get { return r_OwnerName; }
        }

        public string OwnerPhone
        {
            get { return r_OwnerPhone; }
        }

        public eStatus Status
        {
            get { return m_Status; }
            set { m_Status = value; }
        }

        public Vehicle Vehicle
        {
            get { return r_Vehicle; }
        }

        public override string ToString()
        {
            return string.Format(
                @"Owner name: {0}
Owner phone: {1}
Car treatment status: {2},
{3}",
                r_OwnerName,
                r_OwnerPhone,
                m_Status,
                r_Vehicle.ToString());
        }

        public override bool Equals(object i_Object)
        {
            bool isEquals = false;
            GarageVehicle objectToCompareTo = i_Object as GarageVehicle;

            if (objectToCompareTo != null)
            {
                isEquals = r_OwnerName == objectToCompareTo.OwnerPhone
                    && r_OwnerName == objectToCompareTo.OwnerName
                    && r_Vehicle.Equals(objectToCompareTo.Vehicle);
            }

            return isEquals;
        }
    }

}


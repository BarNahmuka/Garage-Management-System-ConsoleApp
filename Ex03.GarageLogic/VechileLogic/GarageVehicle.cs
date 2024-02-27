using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageVehicle
    {
        public Vehicle m_Vehicle;
        private string m_OwnerName;
        private string m_OwnerPhone;
        private eStatus m_Status;

        public GarageVehicle(string i_OwnerName, string i_OwnerPhone, Vehicle i_Vehicle)
        {
            m_Vehicle = i_Vehicle;
            m_OwnerName = i_OwnerName;
            m_OwnerPhone = i_OwnerPhone;
            m_Status = eStatus.Repair;
        }
        public string OwnerName
        {
            get { return m_OwnerName; }
        }

        public string OwnerPhone
        {
            get { return m_OwnerPhone; }
        }

        public eStatus Status
        {
            get { return m_Status; }
            set { m_Status = value; }
        }

        public Vehicle Vehicle
        {
            get { return m_Vehicle; }
        }
        public override string ToString()
        {
            return string.Format(
                @"Owner name: {0}
Owner phone: {1}
Car treatment status: {2}
{3}",
                m_OwnerName,
                m_OwnerPhone,
                m_Status,
                m_Vehicle.ToString());
        }

        public override bool Equals(object i_Object)
        {
            bool isEquals = false;
            GarageVehicle objectToCompareTo = i_Object as GarageVehicle;
            if (objectToCompareTo != null)
            {
                isEquals = m_OwnerName == objectToCompareTo.OwnerPhone
                    && m_OwnerName == objectToCompareTo.OwnerName
                    && m_Vehicle.Equals(objectToCompareTo.Vehicle);
            }

            return isEquals;
        }
    }

}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VechileLogic
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

    }
}

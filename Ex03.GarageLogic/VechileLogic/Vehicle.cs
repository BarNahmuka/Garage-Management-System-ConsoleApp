using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VechileLogic
{
    public abstract class Vehicle
    {
        private String m_Model;
        private String m_LicenseNumber;
        protected float m_EnergyLeft;
        //private List<Wheels;

        public Vehicle(string i_Model, string i_LicenseNumber, float i_EnergyLeft)
        {
            m_Model = i_Model;
            m_LicenseNumber = i_LicenseNumber;
            m_EnergyLeft = i_EnergyLeft;
        }

        public String model
        {
            get { return m_Model; }
            set { m_Model = value; }
        }

        public String licenseNumber
        {
            get { return m_LicenseNumber; }
            set { m_LicenseNumber = value; }
        }

        public float energyLeft
        {
            get { return m_EnergyLeft; }
            set { m_EnergyLeft = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private String m_ModelName;
        private String m_LicenseNumber;
        protected float m_EnergyLeft;
        protected List<Wheel> m_Wheels;

        public Vehicle(string i_ModelName, string i_LicenseNumber, float i_EnergyLeft, List<Wheel> i_Wheels)
        {
            m_ModelName = i_ModelName;
            m_LicenseNumber = i_LicenseNumber;
            m_EnergyLeft = i_EnergyLeft;
            m_Wheels = i_Wheels;
        }

        public String Model
        {
            get { return m_ModelName; }
            set { m_ModelName = value; }
        }

        public String LicenseNumber
        {
            get { return m_LicenseNumber; }
            set { m_LicenseNumber = value; }
        }

        public float EnergyLeft
        {
            get { return m_EnergyLeft; }
            set { m_EnergyLeft = value; }
        }

        public List<Wheel> Wheels
        {
            get { return m_Wheels; }
            set {m_Wheels = value; }
        }

        public override bool Equals(object i_Object)
        {
            bool equals = false;
            if (i_Object is Vehicle)
            {
                equals = (i_Object as Vehicle).LicenseNumber == m_LicenseNumber;
            }

            return equals;
        }

        public override string ToString()
        {
            StringBuilder vehicleDataString = new StringBuilder();
            vehicleDataString.AppendLine(string.Format("Model name: {0}", m_ModelName));
            vehicleDataString.AppendLine(string.Format("License Number: {0}", m_LicenseNumber));
            vehicleDataString.Append(string.Format("Energy left: {0}", m_EnergyLeft));

            foreach(Wheel wheel in m_Wheels)
            {
                vehicleDataString.AppendLine(string.Format("Wheel: {0}", wheel.ToString()));
            }

            return vehicleDataString.ToString();
        }
    }
}

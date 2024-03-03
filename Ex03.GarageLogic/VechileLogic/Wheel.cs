using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly String r_ManufacturerName;
        private float m_TirePressure;
        private readonly float r_MaxPressure;

        public Wheel(String i_ManufacturerName, float i_TirePressure, float i_MaxPressure)
        {
            r_ManufacturerName = i_ManufacturerName;
            m_TirePressure = i_TirePressure;
            r_MaxPressure = i_MaxPressure;
        }

        public void Pump(float i_PressureToAdd)
        {
            if (i_PressureToAdd + m_TirePressure <= r_MaxPressure)
            {
                m_TirePressure = i_PressureToAdd + m_TirePressure;
            }
            else
            {
                throw new ValueOutOfRangeException(0, r_MaxPressure - m_TirePressure);
            }
        }

        public string ManufacturerName
        {
            get { return r_ManufacturerName; }
        }

        public float TirePressure
        {
            get { return m_TirePressure; }
            set { m_TirePressure = value; }
        }

        public float MaxPressure
        {
            get { return r_MaxPressure; }
        }

        public override string ToString()
        {
            return string.Format(
                @"Manufacturer Name: {0}, Tire Pressure: {1}, Max Preesure : {2}",
                r_ManufacturerName,
                m_TirePressure,
                r_MaxPressure);
        }
    }
}

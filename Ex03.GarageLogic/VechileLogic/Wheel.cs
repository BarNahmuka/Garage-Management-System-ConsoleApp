using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private String m_ManufacturerName;
        private float m_TirePressure;
        private float m_MaxPressure;

        public Wheel(String i_ManufacturerName, float i_TirePressure, float i_MaxPressure)
        {
            m_ManufacturerName = i_ManufacturerName;
            m_TirePressure = i_TirePressure;
            m_MaxPressure = i_MaxPressure;
        }

        public void pump(float i_PressureToAdd)
        {
            if (i_PressureToAdd + m_TirePressure <= m_MaxPressure)
            {
                m_TirePressure = i_PressureToAdd + m_TirePressure;
            }
            else
            {
                throw new ValueOutOfRangeException(0, m_MaxPressure - m_TirePressure);
            }
        }

        public string ManufacturerName
        {
            get { return m_ManufacturerName; }
        }

        public float TirePressure
        {
            get { return m_TirePressure; }
            set { m_TirePressure = value; }
        }

        public float MaxPressure
        {
            get { return m_MaxPressure; }
        }

        public override string ToString()
        {
            return string.Format(
                @"Manufacturer Name: {0}
Tire Pressure: {1}
Max Preesure : {2}",
                m_ManufacturerName,
                m_TirePressure,
                m_MaxPressure);
        }
    }
}

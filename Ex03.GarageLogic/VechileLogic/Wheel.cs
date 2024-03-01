using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public struct Wheel
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
        }

        public float MaxPressure
        {
            get { return m_MaxPressure; }
        }
    }
}

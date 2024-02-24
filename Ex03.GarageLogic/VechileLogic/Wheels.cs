using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VechileLogic
{
    class Wheels
    {
        private String m_ManufacturerName;
        private float m_TirePressure;
        private float m_MaxPressure;

        public void pump(float i_PressureToAdd)
        {
            if(i_PressureToAdd + m_TirePressure <= m_MaxPressure)
            {
                m_TirePressure = i_PressureToAdd + m_TirePressure;
            }
        }

    }
}

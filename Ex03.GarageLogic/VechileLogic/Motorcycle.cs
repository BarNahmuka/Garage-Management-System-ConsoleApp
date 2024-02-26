using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VechileLogic
{
    class Motorcycle
    {
        private eLicenseKind m_LicenseKind;
        private int m_EngineSize;

        public Motorcycle(eLicenseKind i_LicenseKind, int i_EngineSize)
        {
            m_LicenseKind = i_LicenseKind;
            m_EngineSize = i_EngineSize;
        }

        public eLicenseKind LicenseKind
        {
            get { return m_LicenseKind; }
        }

        public int EngineSize
        {
            get { return m_EngineSize; }
        }
    }
}

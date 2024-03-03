using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Motorcycle
    {
        private readonly eLicenseKind r_LicenseKind;
        private readonly int r_EngineSize;

        public Motorcycle(eLicenseKind i_LicenseKind, int i_EngineSize)
        {
            r_LicenseKind = i_LicenseKind;
            r_EngineSize = i_EngineSize;
        }

        public eLicenseKind LicenseKind
        {
            get { return r_LicenseKind; }
        }

        public int EngineSize
        {
            get { return r_EngineSize; }
        }
        public override string ToString()
        {
            return string.Format(
                @"License type: {0}
Engine volume: {1}",
                r_LicenseKind.ToString(),
                r_EngineSize);
        }
    }
}

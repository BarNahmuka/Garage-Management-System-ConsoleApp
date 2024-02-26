﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VechileLogic
{
    class GasolineMotorcycle : GasolineVehicle
    {
        Motorcycle m_Motorcycle;

        public GasolineMotorcycle(String i_Model, String i_LicenseNumber, float i_EnergyLeft, eFuel i_GasolineType, float i_CurrentGasInTankPerLiter, float i_MaxGasInTankPerLiter, eLicenseKind i_LicenseKind, int i_EngineSize) : base(i_Model, i_LicenseNumber, i_EnergyLeft, i_GasolineType, i_CurrentGasInTankPerLiter, i_MaxGasInTankPerLiter)
        {
            m_Motorcycle = new Motorcycle(i_LicenseKind, i_EngineSize);
        }

        public Motorcycle Motorcycle
        {
            get { return m_Motorcycle; }
        }
    }
}

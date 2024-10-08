﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class GasolineTruck : GasolineVehicle
    {
        private readonly bool r_IsTransferingHazard;
        private readonly float r_CargoSize;

        public GasolineTruck(String i_Model, String i_LicenseNumber, float i_EnergyLeft, List<Wheel> i_Wheels, eFuel i_GasolineType, float i_CurrentGasInTankPerLiter, float i_MaxGasInTankPerLiter, bool i_IsTransferingHazard, float i_CargoSize) : base(i_Model, i_LicenseNumber, i_EnergyLeft, i_Wheels, i_GasolineType, i_CurrentGasInTankPerLiter, i_MaxGasInTankPerLiter)
        {
            r_IsTransferingHazard = i_IsTransferingHazard;
            r_CargoSize = i_CargoSize;
        }

        public bool IsTransferingHazard
        {
            get { return r_IsTransferingHazard; }
        }

        public float CargoSize
        {
            get { return r_CargoSize; }
        }

        public override string ToString()
        {
            return string.Format(
                @"{0}
Has hazardous substances: {1}
Cargo Size: {2}",
                base.ToString(),
                r_IsTransferingHazard,
                r_CargoSize);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class ElectricMotorcycle : ElectricVehicle
    {
        Motorcycle m_Motorcycle;
        public ElectricMotorcycle(String i_Model, String i_LicenseNumber, float i_EnergyLeft, List<Wheel> i_Wheels, float i_BatteryTimeLeftPerHours, float i_BatteryTimeMaxPerHours, eLicenseKind i_LicenseKind, int i_EngineSize) :base(i_Model, i_LicenseNumber, i_EnergyLeft, i_Wheels, i_BatteryTimeLeftPerHours, i_BatteryTimeMaxPerHours)
        {
            m_Motorcycle = new Motorcycle(i_LicenseKind, i_EngineSize);
        }

        public Motorcycle Motorcycle
        {
            get { return m_Motorcycle; }
        }
        public override string ToString()
        {
            return string.Format(
                @"{0}
{1}",
                base.ToString(),
                m_Motorcycle.ToString());
        }
    }
}

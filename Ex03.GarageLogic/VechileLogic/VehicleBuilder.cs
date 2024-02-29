using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public sealed class VehicleBuilder
    {
        private const eFuel k_GasTruckFuelType = eFuel.Soler;
        private const eFuel k_GasMotorcycleFuelType = eFuel.Octan98;
        private const eFuel k_GasCarFuelType = eFuel.Octan95;
        private const float k_ElectricMotorcycleMaxBatteyTime = 2.8F;
        private const float k_ElectricCarMaxBatteryTime = 4.8F;
        private const float k_GasMotorcycleMaxFuelAmount = 5.8F;
        private const float k_MotorcycleMaxEngineVolume = 10;
        private const float k_GasCarMaxFuelAmount = 58F;
        private const float k_GasTruckMaxFuelAmount = 110F;
        private const float k_GasTruckMaxWeight = 15F;
        private float m_GasVehicleCurrentFuelAmount;
        private float m_BatteryTimeLeft;
        private string m_ModelName;
        private string m_LicenseNumber;
        private float m_EnergyLeft;
        //private List<Wheel> m_Wheels;
        private eEnergy m_VehicleEnergySource;
        private eVehicle m_VehicleType;
        private eLicenseKind m_LicenseType;
        private int m_EngineVolume;
        private eCarColor m_Color;
        private eNumbersOfDoors m_DoorsAmount;
        private bool m_IsTransferingHazard;
        private float m_CargoSize;

        public eCarColor Color
        {
            get { return m_Color; }
            set { m_Color = value; }
        }

        public eNumbersOfDoors DoorsAmount
        {
            get { return m_DoorsAmount; }
            set { m_DoorsAmount = value; }
        }

        public bool IsTransferingHazard
        {
            get { return IsTransferingHazard; }
            set { m_IsTransferingHazard = value; }
        }

        private void validateInputInRange(float i_ValueToInsert, float i_MaxCapacity)
        {
            if (!(i_ValueToInsert >= 0 && i_ValueToInsert <= i_MaxCapacity))
            {
                throw new ValueOutOfRangeException(0, i_MaxCapacity);
            }
        }

        public float GasVehicleCurrentFuelAmount
        {
            get { return m_GasVehicleCurrentFuelAmount; }
            set
            {
                switch (m_VehicleType)
                {
                    case eVehicle.Car:
                        {
                            validateInputInRange(value, k_GasCarMaxFuelAmount);
                            break;
                        }

                    case eVehicle.Motorcycle:
                        {
                            validateInputInRange(value, k_GasMotorcycleMaxFuelAmount);
                            break;
                        }

                    case eVehicle.Truck:
                        {
                            validateInputInRange(value, k_GasTruckMaxFuelAmount);
                            break;
                        }
                }

                m_GasVehicleCurrentFuelAmount = value;
            }
        }

        public float CargoSize
        {
            get { return m_CargoSize; }
            set
            {
                validateInputInRange(value, k_GasTruckMaxWeight);
                m_CargoSize = value;
            }
        }

        public float BatteryTimeLeft
        {
            get { return m_BatteryTimeLeft; }
            set
            {
                switch (m_VehicleType)
                {
                    case eVehicle.Car:
                        {
                            validateInputInRange(value, k_ElectricCarMaxBatteryTime);
                            break;
                        }

                    case eVehicle.Motorcycle:
                        {
                            validateInputInRange(value, k_ElectricMotorcycleMaxBatteyTime);
                            break;
                        }
                }

                m_BatteryTimeLeft = value;
            }
        }

        public string ModelName
        {
            get { return m_ModelName; }
            set
            {
                GarageVehicleBuilder.CheckIfStringContainsOnlyLetters(value);
                m_ModelName = value;
            }
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
            set
            {
                m_LicenseNumber = value; 
            }
        }

        public float EnergyLeft
        {
            get { return m_EnergyLeft; }
            set { m_EnergyLeft = value; }
        }

        /*public List<Wheel> Wheels
        {
            get { return m_Wheels; }
            set { m_Wheels = value; }
        }*/

        public eLicenseKind LicenseType
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value; }
        }

        public eEnergy VehicleEnergySource
        {
            get { return m_VehicleEnergySource; }
            set { m_VehicleEnergySource = value; }
        }

        public eVehicle VehicleType
        {
            get { return m_VehicleType; }
            set { m_VehicleType = value; }
        }

        public int EngineVolume
        {
            get { return m_EngineVolume; }
            set
            {
                validateInputInRange(value, k_MotorcycleMaxEngineVolume);
                m_EngineVolume = value;
            }
        }
        public void setVehicleToCar()
        {
            VehicleType = eVehicle.Car;
        }
        public void setVehicleToMotorcycle()
        {
            VehicleType = eVehicle.Motorcycle;
        }
        public void setVehicleToTruck()
        {
            VehicleType = eVehicle.Truck;
        }
        public void setVehicleToElectric()
        {
            VehicleEnergySource = eEnergy.electricity;
        }
        public void setVehicleToGasoline()
        {
            VehicleEnergySource = eEnergy.Gasoline;
        }

        private GasolineTruck createGasTruck()
        {
            m_EnergyLeft = (m_GasVehicleCurrentFuelAmount / k_GasTruckMaxFuelAmount) * 100;
            return new GasolineTruck(
                m_ModelName,
                m_LicenseNumber,
                m_EnergyLeft,
                //Wheels,
                k_GasTruckFuelType,
                m_GasVehicleCurrentFuelAmount,
                k_GasTruckMaxFuelAmount,
                m_IsTransferingHazard,
                m_CargoSize);
        }

        private GasolineCar createGasCar()
        {
            m_EnergyLeft = (m_GasVehicleCurrentFuelAmount / k_GasCarMaxFuelAmount) * 100;
            return new GasolineCar(
                m_ModelName,
                m_LicenseNumber,
                m_EnergyLeft,
                //m_Wheels,
                k_GasCarFuelType,
                m_GasVehicleCurrentFuelAmount,
                k_GasCarMaxFuelAmount,
                m_Color,
                DoorsAmount);
        }

        private GasolineMotorcycle createGasMotorcycle()
        {
            m_EnergyLeft = (m_GasVehicleCurrentFuelAmount / k_GasMotorcycleMaxFuelAmount) * 100;
            return new GasolineMotorcycle(
                m_ModelName,
                m_LicenseNumber,
                m_EnergyLeft,
                //m_Wheels,
                k_GasMotorcycleFuelType,
                m_GasVehicleCurrentFuelAmount,
                k_GasMotorcycleMaxFuelAmount,
                m_LicenseType,
                m_EngineVolume);
        }

        private ElectricCar createElectricCar()
        {
            m_EnergyLeft = (m_BatteryTimeLeft / k_ElectricCarMaxBatteryTime) * 100;
            return new ElectricCar(
                m_ModelName,
                m_LicenseNumber,
                //m_Wheels,
                m_EnergyLeft,
                m_BatteryTimeLeft,
                k_ElectricCarMaxBatteryTime,
                m_Color,
                DoorsAmount);
        }

        private ElectricMotorcycle createElectricMotorcycle()
        {
            m_EnergyLeft = (m_BatteryTimeLeft / k_ElectricMotorcycleMaxBatteyTime) * 100;
            return new ElectricMotorcycle(
                m_ModelName,
                m_LicenseNumber,
                //m_Wheels,
                m_EnergyLeft,
                m_BatteryTimeLeft,
                k_ElectricMotorcycleMaxBatteyTime,
                m_LicenseType,
                m_EngineVolume);
        }

        public Vehicle CreateVehicle()
        {
            Vehicle vehicle = null;
            switch (m_VehicleType)
            {
                case eVehicle.Car:
                    {
                        if (m_VehicleEnergySource == eEnergy.Gasoline)
                        {
                            vehicle = createGasCar();
                        }
                        else
                        {
                            vehicle = createElectricCar();
                        }

                        break;
                    }

                case eVehicle.Truck:
                    {
                        vehicle = createGasTruck();
                        break;
                    }

                case eVehicle.Motorcycle:
                    {
                        if (m_VehicleEnergySource == eEnergy.Gasoline)
                        {
                            vehicle = createGasMotorcycle();
                        }
                        else
                        {
                            vehicle = createElectricMotorcycle();
                        }

                        break;
                    }
            }

            return vehicle;
        }
    }
}

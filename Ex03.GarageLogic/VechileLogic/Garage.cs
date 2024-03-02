using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private List<GarageVehicle> m_VehiclesInGarage;

        public Garage()
        {
            m_VehiclesInGarage = new List<GarageVehicle>();
        }

        public List<GarageVehicle> VehiclesInGarage
        {
            get { return m_VehiclesInGarage; }
        }

        private GarageVehicle searchVehicleInGarage(string i_LicensePlate)
        {
            return m_VehiclesInGarage.Find(GarageVehicle => GarageVehicle.Vehicle.LicenseNumber == i_LicensePlate);
        }

        public void AddVehicleToGarage(GarageVehicle i_GarageVehicle)
        {
            if(searchVehicleInGarage(i_GarageVehicle.Vehicle.LicenseNumber) == null)
            {
                m_VehiclesInGarage.Add(i_GarageVehicle);
            }
        }

        public bool IsVehicleInGarage(string i_LicenseNumber)
        {
            return searchVehicleInGarage(i_LicenseNumber) != null;
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, eStatus i_Status)
        {
            GarageVehicle VehicleToChangeStatus = searchVehicleInGarage(i_LicenseNumber);
            if (VehicleToChangeStatus != null)
            {
                VehicleToChangeStatus.Status = i_Status;
            }
        }

        public string GetVehiclesLicensePlates(eStatus? i_Status)
        {
            StringBuilder licenseNumbersString = new StringBuilder();
            if (i_Status == null)
            {
                m_VehiclesInGarage.ForEach(garageVehicle => licenseNumbersString.AppendLine(garageVehicle.Vehicle.LicenseNumber));
            }
            else
            {
                foreach (GarageVehicle garageVehicle in m_VehiclesInGarage)
                {
                    if (garageVehicle.Status.Equals(i_Status))
                    {
                        licenseNumbersString.AppendLine(garageVehicle.Vehicle.LicenseNumber);
                    }
                }
            }

            return licenseNumbersString.ToString();
        }
        public void RefuelGasVehicle(String i_license_number, float i_LitersToRefuel, eFuel i_FuelType)
        {
            GarageVehicle garageVehicle = searchVehicleInGarage(i_license_number);
            if (garageVehicle != null)
            {
                GasolineVehicle gasolineVehicle = garageVehicle.Vehicle as GasolineVehicle;
                if(gasolineVehicle != null)
                {
                    gasolineVehicle.RefuelTank(i_LitersToRefuel, i_FuelType);
                }
                else
                {
                    throw new Exception("Trying to fuel a vehicl that is not gasoline based");
                }
            }
            else
            {
                throw new Exception("Vehicle not found");
            }
        }

        public void RechargeBattery(String i_license_number, float i_HoursToCharge)
        {
            GarageVehicle garageVehicle = searchVehicleInGarage(i_license_number);

            if (garageVehicle != null)
            {
                ElectricVehicle electricVehicle = garageVehicle.Vehicle as ElectricVehicle;
                if (electricVehicle != null)
                {
                    electricVehicle.ChargeBattery(i_HoursToCharge);
                }
                else
                {
                    throw new Exception("Trying to Recharge a vehicle that is not electric ");
                }
            }
            else
            {
                throw new Exception("Vehicle not found");
            }
        }

        public void PumpWheels(String i_license_number)
        {
            GarageVehicle garageVehicle = searchVehicleInGarage(i_license_number);

            if (garageVehicle != null)
            {
                foreach (Wheel wheel in garageVehicle.m_Vehicle.Wheels)
                {
                    wheel.pump(wheel.MaxPressure - wheel.TirePressure);
                }

            }
                else
                {
                    throw new Exception("Failed to pump");
                }
        }

        public String getVehicleInformation(String i_LicenseNumber)
        {
            GarageVehicle garageVehicle = searchVehicleInGarage(i_LicenseNumber);
            String vehicleInfo;

            if(garageVehicle != null)
            {
                vehicleInfo = garageVehicle.ToString();
            }
            else
            {
                throw new Exception("The vehicle not found in the garage");
            }

            return vehicleInfo;
        }
    }
}

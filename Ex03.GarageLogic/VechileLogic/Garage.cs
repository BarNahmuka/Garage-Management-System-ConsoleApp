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
    }
}

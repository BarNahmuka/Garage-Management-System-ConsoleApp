using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
	public class WheelBuilder
	{
		private const int k_NumberOfWheelsForMotorcycle = 2;
		private const int k_NumberOfWheelsForCar = 5;
		private const int k_NumberOfWheelsForTruck = 12;
		private const float k_TruckWheelMaxAirPressure = 28F;
		private const float k_MotorcycleWheelMaxAirPressure = 29F;
		private const float k_CarWheelMaxAirPressure = 30F;
		private string m_ManufacturerName;
		private float m_MaxPressure;
		private float m_TirePressure;

		public Wheel CreateWheel()
		{
			return new Wheel(m_ManufacturerName, m_TirePressure, m_MaxPressure);
		}

		public float TirePressure
		{
			get { return m_TirePressure; }
			set
			{
				if (value >= 0 && value <= m_MaxPressure)
				{
					m_TirePressure = value;
				}
				else
				{
					throw new ValueOutOfRangeException(0, m_MaxPressure);
				}
			}
		}
		public float MaxWheelpressure
		{
			get { return m_MaxPressure; }
			set { m_MaxPressure = value; }
		}

		public string ManufacturerName
		{
			get { return m_ManufacturerName; }
			set {
				GarageVehicleBuilder.CheckIfStringContainsOnlyLetters(value);
				m_ManufacturerName = value; }
		}

		public int NumberOfWheelsForMotorcycle
		{
			get { return k_NumberOfWheelsForMotorcycle; }
		}

		public int NumberOfWheelsForCar
		{
			get { return k_NumberOfWheelsForCar; }
		}

		public int NumberOfWheelsForTruck
		{
			get { return k_NumberOfWheelsForTruck; }
		}

		public float TruckWheelMaxAirPressure
		{
			get { return k_TruckWheelMaxAirPressure; }
		}

		public float MotorcycleWheelMaxAirPressure
		{
			get { return k_MotorcycleWheelMaxAirPressure; }
		}

		public float CarWheelMaxAirPressure
		{
			get { return k_CarWheelMaxAirPressure; }
		}

	}
}

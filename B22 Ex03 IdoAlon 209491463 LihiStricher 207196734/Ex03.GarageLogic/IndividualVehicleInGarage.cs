namespace Ex03.GarageLogic
{
    public class IndividualVehicleInGarage
    {
        private readonly Vehicle r_RepairVehicle;
        private VehicleProperties m_Properties;

        public IndividualVehicleInGarage(Vehicle i_RepairVehicle)
        {
            r_RepairVehicle = i_RepairVehicle;
            m_Properties = new VehicleProperties();
        }

        public VehicleProperties Properties
        {
            get
            {
                return m_Properties;
            }

            set
            {
                m_Properties = value;
            }
        }

        public Vehicle RepairVehicle
        {
            get
            {
                return r_RepairVehicle;
            }
        }
    }
}

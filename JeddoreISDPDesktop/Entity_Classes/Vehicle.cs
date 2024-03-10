namespace JeddoreISDPDesktop.Entity_Classes
{
    //public sealed class
    public sealed class Vehicle
    {
        //auto implemented properties
        public string vehicleType { get; set; }
        public decimal maxWeight { get; set; }
        public decimal hourlyTruckCost { get; set; }
        public decimal costPerKm { get; set; }
        public string notes { get; set; }

        //default constructor - does nothing
        public Vehicle() { }

        //custom constructor - everything sent in
        public Vehicle(string inVehicleType, decimal inMaxWeight, decimal inHourlyTruckCost,
            decimal inCostPerKm, string inNotes)
        {
            vehicleType = inVehicleType;
            maxWeight = inMaxWeight;
            hourlyTruckCost = inHourlyTruckCost;
            costPerKm = inCostPerKm;
            notes = inNotes;
        }
    }
}

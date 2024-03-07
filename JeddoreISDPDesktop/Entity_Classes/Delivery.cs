namespace JeddoreISDPDesktop.Entity_Classes
{
    //public sealed class
    public sealed class Delivery
    {
        //auto implemented properties
        public int deliveryID { get; set; }
        public decimal distanceCost { get; set; }
        public string vehicleType { get; set; }
        public string notes { get; set; } = null;

        //default constructor - does nothing
        public Delivery() { }

        //custom constructor - everything sent in
        public Delivery(int inDeliveryID, decimal inDistanceCost, string inVehicleType, string inNotes)
        {
            deliveryID = inDeliveryID;
            distanceCost = inDistanceCost;
            vehicleType = inVehicleType;
            notes = inNotes;
        }
    }
}

namespace JeddoreISDPDesktop.Entity_Classes
{
    //public sealed class
    public sealed class Inventory
    {
        //auto implemented properties
        public int itemID { get; set; }
        public int siteID { get; set; }
        public int quantity { get; set; }
        public string itemLocation { get; set; }
        public int reorderThreshold { get; set; }
        public int optimumThreshold { get; set; }
        public string notes { get; set; }

        //extra properties that are needed
        public string name { get; set; }
        public string description { get; set; }

        //default constructor - does nothing
        public Inventory() { }

        //custom constructor - everything sent in
        public Inventory(int inItemID, int inSiteID, int inQuantity, string inItemLocation,
            int inReorderThreshold, int inOptimumThreshold, string inNotes, string inName, string inDescription)
        {
            itemID = inItemID;
            siteID = inSiteID;
            quantity = inQuantity;
            itemLocation = inItemLocation;
            reorderThreshold = inReorderThreshold;
            optimumThreshold = inOptimumThreshold;
            notes = inNotes;
            name = inName;
            description = inDescription;
        }
    }
}

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
        public string siteName { get; set; }
        public string category { get; set; }
        public decimal retailPrice { get; set; }

        //default constructor - does nothing
        public Inventory() { }

        //custom constructor #1 - everything sent in
        public Inventory(int inItemID, int inSiteID, int inQuantity, string inItemLocation,
            int inReorderThreshold, int inOptimumThreshold, string inNotes, string inName, string inDescription,
            string inSiteName, string inCategory, decimal inRetailPrice)
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
            siteName = inSiteName;
            category = inCategory;
            retailPrice = inRetailPrice;
        }

        //custom constructor #2 - everything sent in except for category and retail price
        public Inventory(int inItemID, int inSiteID, int inQuantity, string inItemLocation,
            int inReorderThreshold, int inOptimumThreshold, string inNotes, string inName, string inDescription,
            string inSiteName)
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
            siteName = inSiteName;
        }
    }
}

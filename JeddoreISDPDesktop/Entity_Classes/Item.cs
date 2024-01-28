namespace JeddoreISDPDesktop.Entity_Classes
{
    //public sealed class
    public sealed class Item
    {
        //auto implemented properties
        public int itemID { get; set; }
        public string name { get; set; }
        public string sku { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public decimal weight { get; set; }
        public int caseSize { get; set; }
        public decimal costPrice { get; set; }
        public decimal retailPrice { get; set; }
        public int supplierID { get; set; }
        public byte active { get; set; }
        public string notes { get; set; }

        //default constructor - does nothing
        public Item() { }

        //custom constructor - everything sent in
        public Item(int inItemID, string inName, string inSku, string inDescription, string inCategory,
            decimal inWeight, int inCaseSize, decimal inCostPrice, decimal inRetailPrice,
            int inSupplierID, byte inActive, string inNotes)
        {
            itemID = inItemID;
            name = inName;
            sku = inSku;
            description = inDescription;
            category = inCategory;
            weight = inWeight;
            caseSize = inCaseSize;
            costPrice = inCostPrice;
            retailPrice = inRetailPrice;
            supplierID = inSupplierID;
            active = inActive;
            notes = inNotes;
        }
    }
}

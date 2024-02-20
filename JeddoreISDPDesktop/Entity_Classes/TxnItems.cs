namespace JeddoreISDPDesktop.Entity_Classes
{
    //public sealed class
    public sealed class TxnItems
    {
        //auto implemented properties
        public int txnID { get; set; }
        public int itemID { get; set; }
        public int quantity { get; set; }
        public string notes { get; set; }

        //default constructor - does nothing
        public TxnItems() { }

        //custom constructor - everything sent in
        public TxnItems(int inTxnID, int inItemID, int inQuantity, string inNotes)
        {
            txnID = inTxnID;
            itemID = inItemID;
            quantity = inQuantity;
            notes = inNotes;
        }
    }
}

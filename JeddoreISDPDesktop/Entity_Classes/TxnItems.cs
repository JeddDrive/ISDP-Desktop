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

        //extra properties that are nice to have
        public string name { get; set; }
        public string description { get; set; }
        public int caseSize { get; set; }
        public decimal weight { get; set; }

        //default constructor - does nothing
        public TxnItems() { }

        //custom constructor #1 - everything sent in
        public TxnItems(int inTxnID, int inItemID, int inQuantity, string inNotes,
            string inName, string inDescription, int inCaseSize, decimal inWeight)
        {
            txnID = inTxnID;
            itemID = inItemID;
            quantity = inQuantity;
            notes = inNotes;
            name = inName;
            description = inDescription;
            caseSize = inCaseSize;
            weight = inWeight;
        }

        //custom constructor #2 - just the properties that are in the txnitems table are sent in
        //ex. good for txnitems INSERTs
        public TxnItems(int inTxnID, int inItemID, int inQuantity, string inNotes)
        {
            txnID = inTxnID;
            itemID = inItemID;
            quantity = inQuantity;
            notes = inNotes;
        }
    }
}

namespace JeddoreISDPDesktop.Entity_Classes
{
    //public sealed class
    public sealed class TxnType
    {
        //auto implemented properties
        public string txnType { get; set; }

        //default constructor - does nothing
        public TxnType() { }

        //custom constructor - everything sent in
        public TxnType(string inTxnType)
        {
            txnType = inTxnType;
        }
    }
}

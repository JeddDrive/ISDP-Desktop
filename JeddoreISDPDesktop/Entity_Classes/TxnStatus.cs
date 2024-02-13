namespace JeddoreISDPDesktop.Entity_Classes
{
    //public sealed class
    public sealed class TxnStatus
    {
        //auto implemented properties
        public string statusName { get; set; }
        public string statusDescription { get; set; }

        //default constructor - nothing sent in
        public TxnStatus() { }

        //custom constructor - everything sent in
        public TxnStatus(string inStatusName, string inStatusDescription)
        {
            statusName = inStatusName;
            statusDescription = inStatusDescription;
        }
    }
}

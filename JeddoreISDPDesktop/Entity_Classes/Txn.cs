using System;

namespace JeddoreISDPDesktop.Entity_Classes
{
    //public sealed class
    public sealed class Txn
    {
        //auto implemented properties
        public int txnID { get; set; }
        public int siteIDTo { get; set; }
        public int siteIDFrom { get; set; }
        public string status { get; set; }
        public DateTime shipDate { get; set; }
        public string txnType { get; set; }
        public string barCode { get; set; }
        public DateTime createdDate { get; set; }
        public int deliveryID { get; set; }
        public byte emergencyDelivery { get; set; }
        public string notes { get; set; }

        //extra auto implemented properties
        public string originSite { get; set; }
        public string destinationSite { get; set; }

        //default constructor - does nothing
        public Txn() { }

        //custom constructor - everything sent in
        public Txn(int inTxnID, string inOriginSite, string inDestinationSite, int inSiteIDTo, int inSiteIDFrom, string inStatus, DateTime inShipDate,
            string inTxnType, string inBarCode, DateTime inCreatedDate, int inDeliveryID,
            byte inEmergencyDelivery, string inNotes)
        {
            txnID = inTxnID;
            originSite = inOriginSite;
            destinationSite = inDestinationSite;
            siteIDTo = inSiteIDTo;
            siteIDFrom = inSiteIDFrom;
            status = inStatus;
            shipDate = inShipDate;
            txnType = inTxnType;
            barCode = inBarCode;
            createdDate = inCreatedDate;
            deliveryID = inDeliveryID;
            emergencyDelivery = inEmergencyDelivery;
            notes = inNotes;
        }
    }
}

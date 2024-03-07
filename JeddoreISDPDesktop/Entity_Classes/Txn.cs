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
        public string notes { get; set; } = null;

        //extra auto implemented properties
        public string originSite { get; set; }
        public string destinationSite { get; set; }

        //default constructor - does nothing
        public Txn() { }

        //custom constructor #1 - everything sent in
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

        //custom constructor #2 - everything sent in except for origin site, destination site, notes, and delivery ID (ex. not needed for txn INSERTs)
        //NOTE: may have to come back later and add deliveryID and/or notes as another argument here
        public Txn(int inTxnID, int inSiteIDTo, int inSiteIDFrom, string inStatus, DateTime inShipDate,
            string inTxnType, string inBarCode, DateTime inCreatedDate, byte inEmergencyDelivery)
        {
            txnID = inTxnID;
            siteIDTo = inSiteIDTo;
            siteIDFrom = inSiteIDFrom;
            status = inStatus;
            shipDate = inShipDate;
            txnType = inTxnType;
            barCode = inBarCode;
            createdDate = inCreatedDate;
            emergencyDelivery = inEmergencyDelivery;
        }

        //custom constructor #3 - everything sent in except for deliveryID, emergencyDelivery, and notes
        public Txn(int inTxnID, string inOriginSite, string inDestinationSite, int inSiteIDTo, int inSiteIDFrom, string inStatus, DateTime inShipDate,
            string inTxnType, string inBarCode, DateTime inCreatedDate)
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
        }

        //custom constructor #4
        //can be used for txn updates
        public Txn(int inTxnID, int inSiteIDTo, int inSiteIDFrom, string inStatus, DateTime inShipDate, string inTxnType,
            string inBarCode, int inDeliveryID, byte inEmergencyDelivery)
        {
            txnID = inTxnID;
            siteIDTo = inSiteIDTo;
            siteIDFrom = inSiteIDFrom;
            status = inStatus;
            shipDate = inShipDate;
            txnType = inTxnType;
            barCode = inBarCode;
            deliveryID = inDeliveryID;
            emergencyDelivery = inEmergencyDelivery;
        }
    }
}

namespace JeddoreISDPDesktop
{
    //public sealed class
    public sealed class Supplier
    {
        //auto implemented properties
        public int supplierID { get; set; }
        public string name { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; } = null;
        public string city { get; set; }
        public string country { get; set; }
        public string province { get; set; }
        public string postalCode { get; set; }
        public string phone { get; set; }
        public string contact { get; set; } = null;
        public string notes { get; set; } = null;
        public byte active { get; set; }

        //default constructor - does nothing
        public Supplier() { }

        //custom constructor - everything sent in
        public Supplier(int inSupplierID, string inName, string inAddress1, string inAddress2,
            string inCity, string inCountry, string inProvince, string inPostalCode, string inPhone,
            string inContact, string inNotes, byte inActive)
        {
            supplierID = inSupplierID;
            name = inName;
            address1 = inAddress1;
            address2 = inAddress2;
            city = inCity;
            country = inCountry;
            province = inProvince;
            postalCode = inPostalCode;
            phone = inPhone;
            contact = inContact;
            notes = inNotes;
            active = inActive;
        }
    }
}

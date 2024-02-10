namespace JeddoreISDPDesktop.Entity_Classes
{
    //public sealed class
    public sealed class Site
    {
        //auto implemented properties
        public int siteID { get; set; }
        public string name { get; set; }
        public string provinceID { get; set; }
        public string address { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string postalCode { get; set; }
        public string phone { get; set; }
        public string dayOfWeek { get; set; } = null;
        public int distanceFromWH { get; set; }
        public string notes { get; set; } = null;
        public byte active { get; set; }

        //default constructor - does nothing
        public Site() { }

        //custom constructor - everything sent in
        public Site(int inSiteID, string inName, string inProvinceID, string inAddress, string inAddress2,
            string inCity, string inCountry, string inPostalCode, string inPhone, string inDayOfWeek,
            int inDistanceFromWH, string inNotes, byte inActive)
        {
            siteID = inSiteID;
            name = inName;
            provinceID = inProvinceID;
            address = inAddress;
            address2 = inAddress2;
            city = inCity;
            country = inCountry;
            postalCode = inPostalCode;
            phone = inPhone;
            dayOfWeek = inDayOfWeek;
            distanceFromWH = inDistanceFromWH;
            notes = inNotes;
            active = inActive;
        }
    }
}

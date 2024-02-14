namespace JeddoreISDPDesktop.Entity_Classes
{
    //public sealed class
    public sealed class Province
    {
        //auto implemented properties
        public string provinceID { get; set; }
        public string provinceName { get; set; }
        public string countryCode { get; set; }

        //default constructor - does nothing
        public Province() { }

        //custom constructor
        public Province(string inProvinceID, string inProvinceName, string inCountryCode)
        {
            provinceID = inProvinceID;
            provinceName = inProvinceName;
            countryCode = inCountryCode;
        }
    }
}

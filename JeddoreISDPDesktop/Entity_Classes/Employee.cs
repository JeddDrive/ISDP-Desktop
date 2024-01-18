namespace JeddoreISDPDesktop.Entity_Classes
{
    //public sealed class
    public sealed class Employee
    {
        //auto implemented properties
        public int employeeID { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public byte active { get; set; }
        public int positionID { get; set; }
        public int siteID { get; set; }
        public byte locked { get; set; }
        public string username { get; set; }
        public string notes { get; set; } = null;

        //extra properties that are needed - such as site name and permission level
        public string siteName { get; set; }
        public string permissionLevel { get; set; }

        //default constructor - does nothing
        public Employee() { }

        //custom constructor - everything sent in
        public Employee(int inEmployeeID, string inPassword, string inFirstName, string inLastName,
            string inEmail, byte inActive, int inPositionID, int inSiteID, byte inLocked, string inUsername,
            string inNotes, string inSiteName, string inPermissionLevel)
        {
            employeeID = inEmployeeID;
            password = inPassword;
            firstName = inFirstName;
            lastName = inLastName;
            email = inEmail;
            active = inActive;
            positionID = inPositionID;
            siteID = inSiteID;
            locked = inLocked;
            username = inUsername;
            notes = inNotes;
            siteName = inSiteName;
            permissionLevel = inPermissionLevel;
        }
    }
}

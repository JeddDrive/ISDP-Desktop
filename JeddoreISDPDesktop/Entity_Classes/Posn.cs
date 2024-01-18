namespace JeddoreISDPDesktop.Entity_Classes
{
    //public sealed class
    public sealed class Posn
    {
        //only 2 auto implemented properties
        public int positionID { get; set; }
        public string permissionLevel { get; set; }

        //default constructor - does nothing
        public Posn() { }

        //custom constructor - everything sent in
        public Posn(int inPositionID, string inPermissionLevel)
        {
            positionID = inPositionID;
            permissionLevel = inPermissionLevel;
        }
    }
}

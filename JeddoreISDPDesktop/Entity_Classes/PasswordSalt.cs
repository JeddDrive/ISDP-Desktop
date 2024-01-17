namespace JeddoreISDPDesktop.Entity_Classes
{
    public sealed class PasswordSalt
    {
        //only 2 auto implemented properties
        public int employeeID { get; set; }
        public string passwordSalt { get; set; }

        //default constructor - does nothing
        public PasswordSalt() { }

        //custom constructor - everything sent in
        public PasswordSalt(int inEmployeeID, string inPasswordSalt)
        {
            employeeID = inEmployeeID;
            passwordSalt = inPasswordSalt;
        }
    }
}

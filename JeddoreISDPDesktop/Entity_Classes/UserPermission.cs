using System.Collections.Generic;

namespace JeddoreISDPDesktop.Entity_Classes
{
    //public sealed class
    public sealed class UserPermission
    {
        //auto implemented properties
        public int employeeID { get; set; }
        public List<string> permissionIDList { get; set; }

        //default constructor - does nothing
        public UserPermission() { }

        //custom constructor - everything sent in
        public UserPermission(int inEmployeeID, List<string> inPermissionIDList)
        {
            employeeID = inEmployeeID;
            permissionIDList = inPermissionIDList;
        }
    }
}

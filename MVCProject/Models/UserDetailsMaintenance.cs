using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class UserDetailsMaintenance
    {
        public UserEntity UserInfo { get; set; } = new UserEntity();
        public List<UserEntity> UserData { get; set; } = new List<UserEntity>();
 
    }

    public class UserEntity
    {
        public int User_ID { get; set; }
        public string User_Name { get; set; }
        public string Email_ID { get; set; }
        public int Phone_Number { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public int DeptID { get; set; }
    }
}
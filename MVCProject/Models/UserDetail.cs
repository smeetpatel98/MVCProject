//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserDetail
    {
        public int User_ID { get; set; }
        public string User_Name { get; set; }
        public string Email_ID { get; set; }
        public Nullable<int> Phone_Number { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public Nullable<int> DeptID { get; set; }
    
        public virtual Department_tbl Department_tbl { get; set; }
    }
}

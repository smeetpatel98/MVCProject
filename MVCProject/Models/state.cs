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
    
    public partial class state
    {
        public state()
        {
            this.cities = new HashSet<city>();
        }
    
        public int SId { get; set; }
        public string Sname { get; set; }
        public Nullable<int> CId { get; set; }
    
        public virtual ICollection<city> cities { get; set; }
        public virtual country country { get; set; }
    }
}

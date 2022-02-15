using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class CascadingModel
    {
        public int CId { get; set; }
        public string Cname { get; set; }

        public virtual ICollection<state> states { get; set; }
        
        public int SId { get; set; }
        public string Sname { get; set; }

        public virtual ICollection<city> cities { get; set; }
        public virtual country country { get; set; }
        public int Cityid { get; set; }
        public string Cityname { get; set; }


    }
}
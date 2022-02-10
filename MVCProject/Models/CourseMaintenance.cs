using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class CourseMaintenance
    {
        public CourseEntity CourseInfo { get; set; } = new CourseEntity();
        public List<CourseEntity> CourseData { get; set; } = new List<CourseEntity>();
    }
    public class CourseEntity
    {
        public int  CourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseDept { get; set; }
    }
}
using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MVCProject.Controllers
{
    public class SingleEntryController : Controller
    {
        public object _context { get; private set; }
        public string Message { get; private set; }

        // GET: SingleEntry
        LoginDBEntities db = new LoginDBEntities();
        public ActionResult Index()
        {
            
            CourseMaintenance courseMaintenance = new CourseMaintenance();
            var course = (from Course in db.Courses 
                          select new CourseEntity()     
                          {
                              //modelname = databasename.parameters
                              CourseID= Course.CourseID,
                              CourseDept = Course.CourseDept,
                              CourseName = Course.CourseName

                          }).ToList();
            courseMaintenance.CourseData = course;
          
            return View("Index",courseMaintenance);
                    
        }

        [HttpPost]
        public ActionResult SaveCourse(Course course)
        {

            try
            {
                Course coursestbl = new Course();
                coursestbl.CourseDept = course.CourseDept;
                coursestbl.CourseName = course.CourseName;
                coursestbl.CourseID = course.CourseID;
                db.Courses.Add(coursestbl);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }
        [DataObjectMethod(DataObjectMethodType.Delete)]

        public ActionResult DeleteCourse(Course course)
        {
            //Query syntax

            //Course course1 = (from c in db.Courses
            //                  where c.CourseID == course.CourseID
            //                  select c).FirstOrDefault();
            try
            {
                
                    var course1 = db.Courses.Where(x => x.CourseID == x.CourseID).FirstOrDefault();
                    if (course1 != null)
                    {

                        db.Courses.Remove(course1);
                        db.SaveChanges();
                        //return course1;
                    }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
       
           
            return RedirectToAction("Index");
        }
        public void OnPostSubmit(string selectedDate)
        {
            this.Message = "Selected Date: " + selectedDate;
        }






        //[HttpPost]
        //public ActionResult New()
        //{
        //    using (NorthwindEntities db = new NorthwindEntities())
        //    {
        //        CustomersViewModel model = new CustomersViewModel();
        //        model.Customers = db.Customers.OrderBy(
        //                       m => m.CustomerID).Take(5).ToList();
        //        model.SelectedCustomer = null;
        //        model.DisplayMode = "WriteOnly";
        //        return View("Index", model);
        //    }
        //}

        //[HttpPost]
        //public ActionResult New(MVCProject.Models.Course course)
        //{
        //    using (LoginDBEntities db = new LoginDBEntities())
        //    {

        //        Course model = new Course();
        //        model.CourseName = db.Courses.OrderBy(x => x.CourseName).Take(2).ToList();

        //        return View();
        //    }
        //}



    }
}
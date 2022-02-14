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

        public ActionResult DeleteCourse(int CourseID)
        {
            try
            {

                //var course1 = db.Courses.Where(x => x.CourseID == x.CourseID).FirstOrDefault();
                var delete = db.Courses.Where(x => x.CourseID == CourseID).First();
                      db.Courses.Remove(delete);
                      db.SaveChanges();
                     
                   
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
       
           
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(int CourseID)
        {
            var data = db.Courses.Where(x => x.CourseID == CourseID).FirstOrDefault();
            //{
            //    CourseID = x.CourseID,
            //    CourseName = x.CourseName,
            //    CourseDept = x.CourseDept

            //}).SingleOrDefault();
            return View("Index",data);  
        }
        //[HttpPost]
        //public ActionResult Edit(Course edit1)
        //{
        //    var data = db.Courses.Where(x => x.CourseID == edit1.CourseID).FirstOrDefault();
        //    if (data != null)
        //    {
        //        data.CourseID = edit1.CourseID;
        //        data.CourseName = edit1.CourseName;
        //        data.CourseDept = edit1.CourseDept;
        //        db.SaveChanges();
        //    }
        //    return RedirectToAction("Index");
        //}


        



    }
}
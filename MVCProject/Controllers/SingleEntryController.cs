using MVCProject.Models;
using PagedList;
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
        public ActionResult Index(int CourseID = 0)
        {

            CourseMaintenance courseMaintenance = new CourseMaintenance();
            //bool isUpdate = true;
            if (CourseID > 0)
            {
                var Test = (from u in this.db.Courses
                            where u.CourseID == CourseID
                            select new CourseEntity()
                            {
                                CourseID = u.CourseID,
                                CourseName = u.CourseName,
                                CourseDept = u.CourseDept,

                            }).FirstOrDefault();

                courseMaintenance.CourseInfo = Test;
            }
            else
            {
                courseMaintenance.CourseInfo = new CourseEntity();
            }
            // to print list on partial view
            var course = (from Course in db.Courses
                          select new CourseEntity()
                          {
                              //modelname = databasename.parameters
                              CourseID = Course.CourseID,
                              CourseDept = Course.CourseDept,
                              CourseName = Course.CourseName

                          }).ToList();
            courseMaintenance.CourseData = course;

            return View("Index",courseMaintenance);
                    
        }

        [HttpPost]
        public ActionResult SaveCourse(Course course)
        {
            if (course.CourseID > 0)
            {
                Models.Course course1 = new Models.Course();
                bool isUpdate = true;
                var Test = (from u in this.db.Courses
                            where u.CourseID == course.CourseID
                            select u).FirstOrDefault();
                course1 = Test;

                course1.CourseID = course.CourseID;
                course1.CourseDept = course.CourseDept;
                course1.CourseName = course.CourseName;
                if (isUpdate)
                {
                    this.db.Entry(course1).State = System.Data.Entity.EntityState.Modified;
                }

                var uniqueID = this.db.SaveChanges() > 0 ? course1.CourseID : 0;
            }
            else
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
            }
            return RedirectToAction("Index");
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]

        public ActionResult DeleteCourse(int CourseID)
        {
            try
            {
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
            return View(db.Courses.Find(CourseID));
        }
        public ActionResult Paging(int page = 1, int pagesize = 4)
        {
            List<Course> course = db.Courses.ToList();
            PagedList<Course> model = new PagedList<Course>(course, page, pagesize);
            return View(model);
        }
    }
}
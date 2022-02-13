using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProject.Controllers
{
    public class MultipleEntryController : Controller
    {
        // GET: MultipleEntry
        LoginDBEntities db = new LoginDBEntities();
        public ActionResult Index()
        {
            try
            {
                UserDetailsMaintenance userDetailsMaintenance = new UserDetailsMaintenance();
                var userdetail = (from UserDetail in db.UserDetails
                                  select new UserEntity()
                                  {
                                      //model name= object.database name
                                      User_Name = UserDetail.User_Name,
                                      Email_ID = UserDetail.Email_ID,
                                      Address = UserDetail.Address,
                                      Gender = UserDetail.Gender

                                  }).ToList();
                userDetailsMaintenance.UserData = userdetail;

                return View("Index", userDetailsMaintenance);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]

        public ActionResult SaveUser(UserDetail userDetails)
        {
            try
            {
                UserDetail userdetailtbl = new UserDetail();
                userdetailtbl.User_ID = userDetails.User_ID;
                userdetailtbl.User_Name = userDetails.User_Name;
                userdetailtbl.Address = userDetails.Address;
                userdetailtbl.DOB = userDetails.DOB;
                userdetailtbl.Gender = userDetails.Gender;
                userdetailtbl.Phone_Number = userDetails.Phone_Number;
                userdetailtbl.Email_ID = userDetails.Email_ID;
                userdetailtbl.DeptID = userDetails.DeptID;

                db.UserDetails.Add(userdetailtbl);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        //public ActionResult DeleteUser(UserDetail user)
        //{
        //    //Query syntax

        //    //Course course1 = (from c in db.Courses
        //    //                  where c.CourseID == course.CourseID
        //    //                  select c).FirstOrDefault();

        //    var user1 = ;
        //    if (course1 != null)
        //    {
        //        db.Courses.Remove(course1);
        //        db.SaveChanges();
        //        //return course1;
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}
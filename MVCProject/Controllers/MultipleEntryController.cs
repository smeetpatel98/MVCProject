using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProject.Controllers
{
    public class MultipleEntryController : Controller
    {
        // GET: MultipleEntry
        LoginDBEntities db = new LoginDBEntities();
        public ActionResult Index(int User_ID = 0)
        {
            UserDetailsMaintenance userDetailsMaintenance = new UserDetailsMaintenance();

            if (User_ID > 0)
            {
                var data = (from UserDetail in this.db.UserDetails
                            where UserDetail.User_ID == User_ID
                            select new UserEntity()
                            {
                                //model name= object.database name
                                User_ID = UserDetail.User_ID,
                                User_Name = UserDetail.User_Name,
                                Email_ID = UserDetail.Email_ID,
                                Address = UserDetail.Address,
                                Gender = UserDetail.Gender,
                                // DOB = UserDetail.DOB,
                                //Phone_Number = UserDetail.Phone_Number,
                            }).FirstOrDefault();

                userDetailsMaintenance.UserInfo = data;
            }
            else
            {
                userDetailsMaintenance.UserInfo = new UserEntity();
            }


            var Test = (from u in db.UserDetails
                        select new UserEntity()
                        {
                            //modelname = databasename.parameters

                            User_ID = u.User_ID,
                            User_Name = u.User_Name,
                            Email_ID = u.Email_ID,
                            Address = u.Address,
                            Gender = u.Gender
                        }).ToList();

            userDetailsMaintenance.UserData = Test;


            return View("Index", userDetailsMaintenance);         
        }

        [HttpPost]
        public ActionResult SaveUser(UserDetail userDetails)
        {
            if (userDetails.User_ID > 0)
            {
                Models.UserDetail user1 = new Models.UserDetail();

                bool isUpadte = true;

                var Test = (from u in this.db.UserDetails
                            where u.User_ID == userDetails.User_ID
                            select u).FirstOrDefault();
                user1 = Test;

                user1.User_ID = userDetails.User_ID;
                user1.User_Name = userDetails.User_Name;
                user1.Email_ID = userDetails.Email_ID;
                user1.Address = userDetails.Address;
                user1.Gender = userDetails.Gender;
                user1.DOB = userDetails.DOB;
                user1.Phone_Number = userDetails.Phone_Number;

                if (isUpadte)
                {
                    this.db.Entry(user1).State = System.Data.Entity.EntityState.Modified;
                }
                var UniqueID = this.db.SaveChanges() > 0 ? user1.User_ID : 0;
            }
            else
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
            }
            return RedirectToAction("Index");
        }
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public ActionResult DeleteUser(int User_ID)
        {
            try 
            { 
                var delete = db.UserDetails.Where(x => x.User_ID == User_ID).First();

                db.UserDetails.Remove(delete);
                db.SaveChanges();
                //return course1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }
        public ActionResult EditUser(int User_ID)
        {
            return View(db.UserDetails.Find(User_ID));
        }
    }
}
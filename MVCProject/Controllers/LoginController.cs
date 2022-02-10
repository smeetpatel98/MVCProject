using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(MVCProject.Models.User userModel)
        {
            using (LoginDBEntities db = new LoginDBEntities())
            {
                var userdetails = db.Users.Where(x => x.UserName == userModel.UserName && x.Password == userModel.Password).FirstOrDefault();

                if (userdetails == null)
                {
                    userModel.LoginErrorMessage = "Wrong username or password";

                    return View("Index", userModel);

                }
                else
                {
                    Session["userID"] = userdetails.UserID;
                    //var vm = new User { UserName = userModel.UserName };
                    return RedirectToAction("Index", "Home");
                    //return View(vm);
                }

                //string message = string.Empty;
                //switch(userdetails.)
            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class CascadingController : Controller
    {
        LoginDBEntities db = new LoginDBEntities();
        // GET: Cascading
        public ActionResult Index()
        {
            ViewBag.CountryList = new SelectList(GetCountryList(), "CId", "Cname");

            return View();
        }
        public List<country> GetCountryList()
        {
            List<country> countries = db.countries.ToList();
            return countries;
        }
        [HttpPost]
        public ActionResult GetStateList(int CId)
        {
            List<state> statelist = db.states.Where(x => x.CId == CId).ToList();
            ViewBag.StateOptions = new SelectList(statelist, "SId", "Sname");

            return PartialView("DisplayState");
        }

        [HttpPost]
        public ActionResult GetCityList(int SId)
        {
            List<city> citylist = db.cities.Where(x => x.SId == SId).ToList();
            ViewBag.cityoption = new SelectList(citylist, "Cityid", "Cityname");
            return PartialView("DisplayCities");
        }
    }
}
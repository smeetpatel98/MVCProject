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
        public ActionResult GetSateList(int CId)
        {
            List<state> states = db.states.Where(x => x.CId == CId).ToList();
            ViewBag.Slist = new SelectList(states, "SId", "Sname");
            return PartialView("DisplayStates");
        }
        public ActionResult GetCityList(int SId)
        {
            List<city> cities = db.cities.Where(x => x.SId == SId).ToList();
            ViewBag.Citylist = new SelectList(cities, "Cityid", "Cityname");
            return PartialView("DisplayCities");
        }
    }
}
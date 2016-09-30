using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController()
        {
            _db = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult History()
        {
            var jobs = _db.Jobs;
            var vm = new HistoryViewModel
            {
                Title = "Work History",
                Jobs = jobs.ToList()
            };
            return View(vm);
        }
    }
}
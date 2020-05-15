using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LetsStayConsistent.Models;
using LetsStayConsistent.ViewModels;

namespace LetsStayConsistent.Controllers
{
    public class LogsController : Controller
    {
        private ApplicationDbContext _context;

        public LogsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            List<GoalLog> goalLogs = _context.GoalLogs.ToList();

            var model = new LogsIndexViewModel
            {
                GoalLogs = goalLogs
            };

            return View(model);
        }
    }
}
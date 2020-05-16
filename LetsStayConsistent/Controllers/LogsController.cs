using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LetsStayConsistent.Models;
using LetsStayConsistent.Utilities;
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

        public ActionResult Add()
        {
            var model = new LogsAddViewModel
            {
                Goals = LogsUtility.GetGoalDropdown()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(LogsAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var newModel = new LogsAddViewModel
                {
                    Goals = LogsUtility.GetGoalDropdown(),
                    GoalLog = model.GoalLog
                };

                return View("Add", newModel);
            }

            var log = new GoalLog
            {
                Date = model.GoalLog.Date,
                WasCompleted = model.GoalLog.WasCompleted,
                GoalId = model.GoalId
            };

            _context.GoalLogs.Add(log);
            _context.SaveChanges();

            return RedirectToAction("Index", "Goal");
        }
    }
}
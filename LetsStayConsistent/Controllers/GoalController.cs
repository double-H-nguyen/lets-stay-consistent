using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LetsStayConsistent.Models;
using LetsStayConsistent.ViewModels;

namespace LetsStayConsistent.Controllers
{
    public class GoalController : Controller
    {
        private ApplicationDbContext _context;

        public GoalController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            // Query all goals in database
            List<Goal> goals = _context.Goals.ToList();

            // Query all logs for that specific goal
            foreach (var goal in goals)
            {
                goal.GoalLogs = _context.GoalLogs.Where(log => log.GoalId == goal.Id).ToList();
            }

            var model = new GoalIndexViewModel
            {
                Goals = goals
            };

            return View(model);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(GoalAddViewModel form)
        {
            // verify
            if (!ModelState.IsValid)
            {
                return View("Add", form);
            }

            var goal = new Goal
            {
                Name = form.Name,
                DaysToComplete = form.DaysToComplete,
                Reward = form.Reward
            };

            _context.Goals.Add(goal);
            _context.SaveChanges();

            return RedirectToAction("Index", "Goal");
        }
    }
}
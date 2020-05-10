using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LetsStayConsistent.Models
{
    public class GoalLog
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public bool WasCompleted { get; set; }

        public Goal Goal { get; set; }

        public int GoalId { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LetsStayConsistent.Models
{
    public class Goal
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int DaysToComplete { get; set; }

        [Required]
        public string Reward { get; set; }

        public List<GoalLog> GoalLogs { get; set; }
    }
}
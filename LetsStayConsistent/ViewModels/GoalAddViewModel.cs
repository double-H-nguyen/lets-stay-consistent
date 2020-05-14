using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LetsStayConsistent.ViewModels
{
    public class GoalAddViewModel
    {
        [Required]
        public string Name { get; set; }

        public int DaysToComplete { get; set; }

        [Required]
        public string Reward { get; set; }
    }
}
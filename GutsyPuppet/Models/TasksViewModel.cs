using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GutsyPuppet.Models
{
    public class TasksViewModel
    {

        public IEnumerable<TaskUser> TaskUsers { get; set; } 

        public class TaskUser
        {
            
            public string Name { get; set; }
            public IEnumerable<Task> Tasks { get; set; }

            public double TotalHoursRemaining
            {
                get { return Tasks.Sum(t => t.RemainingHours); }
            }

            public bool TooManyHours => TotalHoursRemaining > 5;
        }

        public class Task
        {

            public string Title { get; set; }
            public string Project { get; set; }
            public double RemainingHours { get; set; }
            public DateTime StartDate { get; set; }
            public string ReportedBy { get; set; }
            public string WorkflowStep { get; set; }

        }

    }
}
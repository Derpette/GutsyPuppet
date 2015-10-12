using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GutsyPuppet.Models
{
    public class WorklogsViewModel
    {

        public IEnumerable<WorklogUser> WorklogUsers { get; set; }
        public DateTime Date { get; set; }

        public WorklogsViewModel()
        {
            WorklogUsers = new List<WorklogUser>();
        }

        public class WorklogUser
        {
            public double LoggedHours { get; set; }
            public string Name { get; set; }

            public bool EnoughHoursLogged => LoggedHours >= 6.0;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GutsyPuppet.Models
{
    public class MenuViewModel
    {

        public IEnumerable<TeamViewModel> Teams { get; set; }

        public MenuViewModel()
        {
            Teams = new List<TeamViewModel>();
        }

        public class TeamViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

    }
}
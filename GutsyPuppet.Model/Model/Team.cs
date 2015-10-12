using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GutsyPuppet.Model.Model
{
    public class Team
    {
        
        public Int16 TeamLevel { get; set; }
        public int TeamId { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }

    }
}

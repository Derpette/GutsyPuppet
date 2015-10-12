using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GutsyPuppet.Model.Repositories.Interfaces;

namespace GutsyPuppet.Model.Repositories.EFRepositories
{
    public class ContextRepository : IContextRepository
    {

        public GutsyPuppetEntities Context { get; }

        public ContextRepository()
        {
            Context = new GutsyPuppetEntities();
        }

    }
}

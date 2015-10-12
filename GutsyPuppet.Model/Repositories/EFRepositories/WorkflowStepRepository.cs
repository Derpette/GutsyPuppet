using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GutsyPuppet.Model.Repositories.Interfaces;

namespace GutsyPuppet.Model.Repositories.EFRepositories
{
    public class WorkflowStepRepository : IWorkflowStepRepository
    {

        private IContextRepository _contextRepository;

        public WorkflowStepRepository(IContextRepository contextRepository)
        {
            _contextRepository = contextRepository;
        }

        public IQueryable<WorkflowStep> GetAllTaskWorkflowSteps()
        {
            return _contextRepository.Context.WorkflowSteps.Where(w => w.WorkflowId == 3).AsNoTracking();
        }

    }
}

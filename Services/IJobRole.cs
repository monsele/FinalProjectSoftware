using FinalProjectSoftware.Models;
using FinalProjectSoftware.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectSoftware.Services
{
    public interface IJobRole
    {
        void Create(JobRole job);
        void Delete(JobRole job);
        JobRole GetJob(int? id);
        IEnumerable<JobRole> GetJobs();
        void Update(int? id, JobRole job);
        JobRole GetJobByActivity(JobActivityViewModel model);
    }

    
}

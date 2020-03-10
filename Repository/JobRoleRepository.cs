using FinalProjectSoftware.Data;
using FinalProjectSoftware.Models;
using FinalProjectSoftware.Services;
using FinalProjectSoftware.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectSoftware.Repository
{
    public class JobRoleRepository : IJobRole
    {
        private readonly ApplicationDbContext context;
        public JobRoleRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Create(JobRole job)
        {
            context.Set<JobRole>().Add(job);
            context.SaveChanges();
        }
        public void Delete(JobRole job)
        {
            context.Set<JobRole>().Remove(job);
            context.SaveChanges();
        }

        public JobRole GetJob(int? id) => context.Set<JobRole>().FirstOrDefault(x => x.Id == id);


        public JobRole GetJobByActivity(JobActivityViewModel model) => context.Set<JobRole>().SingleOrDefault(x => x.Id == model.JobId);


        public IEnumerable<JobRole> GetJobs() => context.Set<JobRole>().ToList();

        

        public void Update(int? id, JobRole job)
        {
            var entity = context.Set<JobRole>().Find(id);
            entity.Position = job.Position;

            context.Set<JobRole>().Update(entity);
            context.SaveChanges();
        }
    }
}

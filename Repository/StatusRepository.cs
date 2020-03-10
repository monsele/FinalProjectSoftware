using FinalProjectSoftware.Data;
using FinalProjectSoftware.Models;
using FinalProjectSoftware.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectSoftware.Repository
{
    public class StatusRepository : IStatus
    {
        private readonly ApplicationDbContext context;
        public StatusRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Create(Status status)
        {
            context.Set<Status>().Add(status);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = context.Set<Status>().Find(id);
            context.Set<Status>().Remove(entity);
            context.SaveChanges();
        }

        public IQueryable<Status> Dropdownlist()
        {
            return context.Set<Status>();
        }

        public Status GetStatus(int? id)
        {
            return context.Set<Status>().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Status> GetStatuses()
        {
            return context.Set<Status>().ToList();
        }

        public void Update(int? id, Status status)
        {
            var entity = context.Set<Status>().Find(id);
            context.Entry(entity).CurrentValues.SetValues(status);
            context.SaveChanges();
        }
    }
}

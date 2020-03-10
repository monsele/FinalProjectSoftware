using FinalProjectSoftware.Data;
using FinalProjectSoftware.Models;
using FinalProjectSoftware.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectSoftware.Repository
{
    public class ActivityRepository : IActivity
    {
        private readonly ApplicationDbContext context;
        public ActivityRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Create(Activitity activity)
        {
            context.Set<Activitity>().Add(activity);
            context.SaveChanges();
        }

        public void Delete(int? id)
        {
            var entity = context.Set<Activitity>().Find(id);
            context.Set<Activitity>().Remove(entity);
            context.SaveChanges();
        }

        public IQueryable DropDownList()
        {
            return context.Set<Activitity>();
        }

        public IEnumerable<Activitity> GetActivitiesByJob(JobRole job)
        {
            return context.Set<Activitity>().Where(x => x.JobRole == job);
        }

        public IEnumerable<Activitity> GetActivitities()
        {
            return context.Set<Activitity>().Include(x=>x.Remark).ToList();
        }
        public Activitity GetActivitity(int? id)
        {
            var entity = context.Set<Activitity>().Find(id);
            return entity;
        }
        public void Update(int id, Activitity obj)
        {
            var entity = context.Set<Activitity>().Find(id);
            context.Entry<Activitity>(entity).CurrentValues.SetValues(obj);
            //context.Set<Activitity>().Update(entity);
            context.SaveChanges();
        }

    }
}

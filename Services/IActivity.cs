using FinalProjectSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectSoftware.Services
{
    public interface IActivity
    {
        void Create(Activitity activity);
        void Delete(int? id);
        IEnumerable<Activitity> GetActivitities();
        Activitity GetActivitity(int? id);
        IQueryable DropDownList();
        void Update(int id, Activitity obj);
        IEnumerable<Activitity> GetActivitiesByJob(JobRole job);
    }
}

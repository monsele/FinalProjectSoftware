using FinalProjectSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectSoftware.Services
{
    public interface IStatus
    {
        void Create(Status status);
        void Delete(int id);
        Status GetStatus(int? id);
        IEnumerable<Status> GetStatuses();
        IQueryable<Status> Dropdownlist();
        void Update(int? id, Status status);
    }
}

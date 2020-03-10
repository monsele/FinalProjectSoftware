using FinalProjectSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectSoftware.Services
{
    public interface IPlacement
    {
        void Create(Placement placement);
        void Delete(int id);
        IQueryable DropDownList();
        IEnumerable<Placement> GetPlacements();
        Placement GetPlacement(int? id);
        void Update(int id, Placement placement);
    }
}

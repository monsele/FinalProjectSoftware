using FinalProjectSoftware.Data;
using FinalProjectSoftware.Models;
using FinalProjectSoftware.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectSoftware.Repository
{
    public class PlacementRepository : IPlacement
    {
        private readonly ApplicationDbContext context;
        public PlacementRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Create(Placement placement)
        {
            context.Set<Placement>().Add(placement);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = context.Set<Placement>().Find(id);
            context.Set<Placement>().Remove(entity);
            context.SaveChanges();
        }

        public IQueryable DropDownList()
        {
            return context.Set<Placement>();
        }

        public Placement GetPlacement(int? id)
        {
            var entity = context.Set<Placement>().Find(id);
            return entity;
        }

        public IEnumerable<Placement> GetPlacements()
        {
            return context.Set<Placement>().ToList();
        }

        public void Update(int id, Placement placement)
        {
            var entity = context.Set<Placement>().Find(id);
            context.Entry(entity).CurrentValues.SetValues(placement);
            context.SaveChanges();
        }
    }
}


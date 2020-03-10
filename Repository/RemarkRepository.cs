using FinalProjectSoftware.Data;
using FinalProjectSoftware.Models;
using FinalProjectSoftware.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectSoftware.Repository
{
    public class RemarkRepository : IRemark
    {
        private readonly ApplicationDbContext context;
        public RemarkRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Create(Remark remark)
        {
            context.Set<Remark>().Add(remark);
            context.SaveChanges();
        }

        public void Delete(int? id)
        {
            var entity = context.Set<Remark>().Find(id);
            context.Set<Remark>().Remove(entity);
            context.SaveChanges();
        }

        public IQueryable dropdownlist() => context.Set<Remark>();

        public Remark GetRemark(int? id) => context.Set<Remark>().FirstOrDefault(x => x.Id == id);

        public Remark GetRemarkByUser(string userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Remark> GetRemarks() => context.Set<Remark>().ToList();

        public void Update(int? id, Remark remark)
        {
            var entity = context.Set<Remark>().Find(id);
            entity.Name = remark.Name;
            context.Set<Remark>().Update(entity);
            context.SaveChanges();
        }
    }
}


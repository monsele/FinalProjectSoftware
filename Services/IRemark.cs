using FinalProjectSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectSoftware.Services
{
    public interface IRemark
    {
        void Create(Remark remark);
        void Delete(int? id);
        IEnumerable<Remark> GetRemarks();
        Remark GetRemark(int? id);
        
        void Update(int? id, Remark remark);
        IQueryable dropdownlist();
    }
}

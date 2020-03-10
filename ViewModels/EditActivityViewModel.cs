using FinalProjectSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectSoftware.ViewModels
{
    public class EditActivityViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Remark> Remarks { get; set; }
        public int JobRoleId { get; set; }
        public JobRole JobRole { get; set; }
        public int RemarkId { get; set; }
        public Remark Remark { get; set; }
    }
}

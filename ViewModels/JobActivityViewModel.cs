using FinalProjectSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectSoftware.ViewModels
{
    public class JobActivityViewModel
    {
        public JobRole Job { get; set; }
        public int JobId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int ActivitityId { get; set; }
        public IEnumerable<Activitity> Activitities { get; set; }
        public string Description { get; set; }
        public string Position { get; set; }
        public int RemarkId { get; set; }
        public Remark Remark { get; set; }
        public IEnumerable<Remark> GetRemarks { get; set; }
    }
}

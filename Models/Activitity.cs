using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectSoftware.Models
{
    public class Activitity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        //public string Remark { get; set; }
        public int? JobRoleId { get; set; }
        public virtual JobRole JobRole { get; set; }
        public int RemarkId { get; set; }
        public Remark Remark { get; set; }
    }
}

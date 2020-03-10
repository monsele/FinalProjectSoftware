using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectSoftware.Models
{
    public class Remark
    {
        public int Id { get; set; }
        public string Name { get; set; }
       public int ActivitityId { get; set; }
       //[ForeignKey("Activitity")]
        public IEnumerable<Activitity> Activitities { get; set; }
    }
}

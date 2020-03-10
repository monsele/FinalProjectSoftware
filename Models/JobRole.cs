using System.Collections.Generic;

namespace FinalProjectSoftware.Models
{
    public class JobRole
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public virtual ICollection<Activitity> Activitities { get; set; }
    }
}
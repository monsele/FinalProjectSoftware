using System.Collections.Generic;

namespace FinalProjectSoftware.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> User { get; set; }
    }
}
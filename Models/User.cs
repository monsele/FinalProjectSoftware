using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectSoftware.Models
{
    public class User:IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string StateOfOrigin { get; set; }
        public string YearsOfExpirience { get; set; }
        //public int ActivitityId { get; set; }
        //public ICollection<Activitity> Activities { get; set; }
        public int JobRoleId { get; set; }
        public virtual JobRole JobRole { get; set; }
        public int PlacementId { get; set; }
        public Placement Placement { get; set; }
        public int StatusId { get; set; }
        public Status status { get; set; }
    }
}

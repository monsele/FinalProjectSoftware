using System;
using System.Collections.Generic;
using System.Text;
using FinalProjectSoftware.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectSoftware.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Activitity> Activitities { get; set; }
        public DbSet<Placement> Placements { get; set; }
        public DbSet<User>Users { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<JobRole> JobRoles { get; set; }
        public DbSet<Remark> Remarks { get; set; }

    }
}

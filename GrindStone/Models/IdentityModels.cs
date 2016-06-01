﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GrindStone.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<Jobs> Jobs { get; set; }
        public DbSet<CustomWorkOrderSections> CustomWorkOrderSections { get; set; }
        public DbSet<CustomWorkOrderForJob> CustomWorkOrderForJob { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<FinishedTask> FinishedTask { get; set; }
        public DbSet<ConnectedJobs> ConnectedJobs { get; set; }
        public DbSet<Alert> Alert { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<CustomTemplates> CustomTemplates { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
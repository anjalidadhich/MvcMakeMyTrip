using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace RoleBasedAuthanticationInMvc.Models
{
    public class ProjectDbContext:DbContext
    {
       
        public ProjectDbContext() : base("name=MakeMyTripDBConnectionString")
        {
            Database.SetInitializer<ProjectDbContext>(new CreateDatabaseIfNotExists<ProjectDbContext>());
        }
        //public virtual DbSet<IdentityRole> Roles { get; set; }
        //public virtual DbSet<ApplicationUser> Users { get; set; }
        //public virtual DbSet<IdentityUserClaim> UserClaims { get; set; }
        //public virtual DbSet<IdentityUserLogin> UserLogins { get; set; }
        //public virtual DbSet<IdentityUserRole> UserRoles { get; set; }
      
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }

        public DbSet<Country> countries { get; set; }
        public DbSet<State> states { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<BookingDetail> bookingDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure domain classes using modelBuilder here..
            //  modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            // base.OnModelCreating(modelBuilder);
            Database.SetInitializer<ProjectDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}
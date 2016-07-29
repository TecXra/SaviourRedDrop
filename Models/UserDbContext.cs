using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace SaviourRedDrop.Models
{
    public class UserDbContext : DbContext
    {

        public UserDbContext() : base("name=UserDbContext")
        {
           // Database.SetInitializer<UserDbContext>(new CreateDatabaseIfNotExists<UserDbContext>());

            // Database.SetInitializer<UserDbContext>(null);
        }
       
        public DbSet<SaviourRDUser> dbUser { set; get; }
        public DbSet<Review> dbReview { set; get; }
        public DbSet<BloodGroup> dbBloodGroup { set; get; }
        public DbSet<City> dbCity { set; get; }

    }
}
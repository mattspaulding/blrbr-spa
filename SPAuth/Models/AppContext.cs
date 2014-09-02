using Blrbr.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SPAuth.Models {
	public class AppContext : IdentityDbContext<User> {
		public AppContext()
			: base("DefaultConnection") {
		}

		//Db Sets
		//public virtual DbSet<Partner> Partners { get; set; }
        public DbSet<Blrb> Blrbs { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<SignUp> SignUps { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<JoinAttempt> JoinAttempts { get; set; }
        public DbSet<Hashtag> Hashtags { get; set; }
        public DbSet<Mention> Mentions { get; set; }
        public DbSet<BlrbStreamItem> BlrbStreamItems { get; set; }

		static AppContext() {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
			Database.SetInitializer<AppContext>(new ApplicationDbInitializer());
        }

		public static AppContext Create() {
			return new AppContext();
        }
	}
}
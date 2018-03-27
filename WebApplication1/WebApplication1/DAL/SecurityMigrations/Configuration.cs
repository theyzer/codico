namespace WebApplication1.DAL.SecurityMigrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplication1.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication1.DAL.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DAL\SecurityMigrations";
        }

        protected override void Seed(WebApplication1.DAL.ApplicationDbContext context)
        {
            //Create a Role Manager
            var roleManager = new RoleManager<IdentityRole>(new
                                          RoleStore<IdentityRole>(context));
            //Create Role Admin if it does not exist
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var roleresult = roleManager.Create(new IdentityRole("Admin"));
            }

          

            //Create a User Manager
            var manager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            //Now the Admin user named admin with password password
            var adminuser = new ApplicationUser
            {
                UserName = "admin@outlook.com",             
                Email = "admin@outlook.com"
            };

            //Assign admin user to role
            if (!context.Users.Any(u => u.UserName == "admin@outlook.com"))
            {
                manager.Create(adminuser, "password");
                manager.AddToRole(adminuser.Id, "Admin");
            }

          

            var user = new ApplicationUser
            {
                UserName = "user@outlook.com",
                Email = "user@outlook.com"
            };

            if (!context.Users.Any(u => u.UserName == "user@outlook.com"))
            {
                manager.Create(user, "password");
            }



            //Create a few generic users
            //for (int i = 1; i <= 4; i++)
            //{
            //    var user = new ApplicationUser
            //    {
            //        UserName = string.Format("user{0}@outlook.com", i.ToString()),
            //      
            //        Email = string.Format("user{0}@outlook.com", i.ToString())
            //    };
            //    if (!context.Users.Any(u => u.UserName == user.UserName))
            //        manager.Create(user, "password");
            //}
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
    


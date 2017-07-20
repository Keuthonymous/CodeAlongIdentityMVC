namespace MVCIdentityCodeAlong.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MVCIdentityCodeAlong.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCIdentityCodeAlong.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVCIdentityCodeAlong.Models.ApplicationDbContext context)
        {
            #region ExampleSeed
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
            #endregion
            //Something 

            if (!context.Roles.Any(r => r.Name == "Management"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(store);

                roleManager.Create(new IdentityRole("Management"));
            }

            if (!context.Users.Any(u => u.UserName == "admin@mail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser { UserName = "admin@mail.com", Email = "admin@mail.com" };
                userManager.Create(user, "Standard-Password");

                userManager.AddToRole(user.Id, "Management");

                user = new ApplicationUser { UserName = "user1@main.com", Email = "user1@main.com" };
                userManager.Create(user, "Standard-Password");

                userManager.AddToRole(user.Id, "Management");

                user = new ApplicationUser { UserName = "user2@main.com", Email = "user2@main.com" };
                userManager.Create(user, "Standard-Password");

                userManager.AddToRole(user.Id, "Management");
            }
        }
    }
}

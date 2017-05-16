using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Software.Models;

namespace Software.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Software.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Software.Models.ApplicationDbContext";
        }

        protected override void Seed(Software.Models.ApplicationDbContext context)
        {
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
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            string[] roleNames = {"Admin", "Guest"};
            IdentityResult roleResult;
            foreach (var roleName in roleNames )
            {
                if (!RoleManager.RoleExists(roleName)) {
                    roleResult = RoleManager.Create(new IdentityRole(roleName));
                }
                
            }
        }
    }
}

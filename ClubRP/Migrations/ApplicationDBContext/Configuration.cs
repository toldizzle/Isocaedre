namespace ClubRP.Migrations.ApplicationDBContext
{
    using Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ClubRP.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ApplicationDBContext";
        }

        protected override void Seed(ClubRP.Models.ApplicationDbContext context)
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
            context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Id = "1", Name = "Administrateurs" });
            context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Id = "2", Name = "Modérateurs" });
            context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Id = "3", Name = "Maîtres" });
            
        }
    }
}

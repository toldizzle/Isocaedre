namespace ClubRP.Migrations.ApplicationDBContext
{
    using Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;

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
            PasswordHasher pass = new PasswordHasher();
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
            ApplicationUser[] users =
            {
                new ApplicationUser
                {
                    Email = "admin@isocaedre.ca",
                    UserName = "admin@isocaedre.ca",
                    PasswordHash = pass.HashPassword("Admin123!"),
                    SecurityStamp = Guid.NewGuid().ToString()
                    //details = new AspNetUserInfoSupp
                    //{
                    //    DateInscription = DateTime.Now,
                    //    Prénom = "Francis",
                    //    Nom = "Henry",
                    //    IdentifiantSTH = "SuPeRaDmIn"
                    //}
                }
            };
            IdentityRole[] roles =
            {
                    new IdentityRole() {Name = "Administrateurs" },
                    new IdentityRole() { Name = "Utilisateurs" },
                    new IdentityRole() { Name = "Modérateurs" }
            };
            context.Users.AddOrUpdate(u => u.UserName, users);
            context.Roles.AddOrUpdate(r => r.Name, roles);
            context.SaveChanges();

            IdentityUserRole[] userroles =
            {
                new IdentityUserRole
                {
                    UserId = context.Users.Where(u => u.UserName == "admin@isocaedre.ca").First().Id,
                    RoleId = context.Roles.Where(r => r.Name == "Modérateurs").First().Id
                }
            };
            context.Set<IdentityUserRole>().AddOrUpdate(ur => new { ur.UserId, ur.RoleId }, userroles);
            context.SaveChanges();
        }
    }
}

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

            AjouterUtilisateur(pass, context);
            AjouterRoles(context);
            AjouterUserRoles(context);
        }

        private static void AjouterUtilisateur(PasswordHasher pass, ApplicationDbContext context)
        {
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
                    //    Pr�nom = "Francis",
                    //    Nom = "Henry",
                    //    IdentifiantSTH = "SuPeRaDmIn"
                    //}
                }
            };
            context.Users.AddOrUpdate(u => u.UserName, users);
            context.SaveChanges();
        }

        private static void AjouterUserRoles(ApplicationDbContext context)
        {
            IdentityUserRole[] userroles =
                        {
                new IdentityUserRole
                {
                    UserId = context.Users.Where(u => u.UserName == "admin@isocaedre.ca").First().Id,
                    RoleId = context.Roles.Where(r => r.Name == "Mod�rateurs").First().Id
                }
            };
            context.Set<IdentityUserRole>().AddOrUpdate(ur => new { ur.UserId, ur.RoleId }, userroles);
            context.SaveChanges();
        }

        private static void AjouterRoles(ApplicationDbContext context)
        {
            IdentityRole[] roles =
                        {
                    new IdentityRole() {Name = "Administrateurs" },
                    new IdentityRole() { Name = "Utilisateurs" },
                    new IdentityRole() { Name = "Mod�rateurs" },
                    new IdentityRole() { Name = "ExclusionForum" },
                    new IdentityRole() { Name = "Ma�tre" },
                    new IdentityRole() { Name = "Joueur" }
            };
            context.Roles.AddOrUpdate(r => r.Name, roles);
            context.SaveChanges();
        }
    }
}

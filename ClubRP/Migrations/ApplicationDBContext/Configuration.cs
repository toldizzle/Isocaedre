namespace ClubRP.Migrations.ApplicationDBContext
{
    using Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using System.Collections.Generic;

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
                    SecurityStamp = Guid.NewGuid().ToString(),
                    details = new AspNetUsersInfoSup
                    {
                        Nom="Henry",
                        Prenom="Francis",
                        ImageData= new byte[0],
                        ImageNom = "",
                        ImageTaille = 0,
                        ImageType = "",
                        Role = "Administrateurs",
                        Fichier = null
                    }
                },
                new ApplicationUser
                {
                    Email = "maitre@isocaedre.ca",
                    UserName = "maitre@isocaedre.ca",
                    PasswordHash = pass.HashPassword("Maitre123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    details = new AspNetUsersInfoSup
                    {
                        Nom="Henry",
                        Prenom="Francis",
                        ImageData= new byte[0],
                        ImageNom = "",
                        ImageTaille = 0,
                        ImageType = "",
                        Role = "Maître",
                        Fichier = null
                    }
                },
                new ApplicationUser
                {
                    Email = "joueur@isocaedre.ca",
                    UserName = "joueur@isocaedre.ca",
                    PasswordHash = pass.HashPassword("Maitre123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    details = new AspNetUsersInfoSup
                    {
                        Nom="Défaut",
                        Prenom="Joueur",
                        ImageData= new byte[0],
                        ImageNom = "",
                        ImageTaille = 0,
                        ImageType = "",
                        Role = "Joueurs",
                        Fichier = null
                    }
                },
                new ApplicationUser
                {
                    Email = "moderateur@isocaedre.ca",
                    UserName = "moderateur@isocaedre.ca",
                    PasswordHash = pass.HashPassword("Moderateur123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    details = new AspNetUsersInfoSup
                    {
                        Nom="Henry",
                        Prenom="Francis",
                        ImageData= new byte[0],
                        ImageNom = "",
                        ImageTaille = 0,
                        ImageType = "",
                        Role = "Modérateurs",
                        Fichier = null
                    }
                }
            };
            //Ajouter un id dans chacune des tables / details et user
            foreach (ApplicationUser u in users)
                u.details.ID = u.Id;
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
                    RoleId = context.Roles.Where(r => r.Name == "Administrateurs").First().Id
                },
                new IdentityUserRole
                {
                    UserId = context.Users.Where(u => u.UserName == "moderateur@isocaedre.ca").First().Id,
                    RoleId = context.Roles.Where(r => r.Name == "Modérateurs").First().Id
                },
                new IdentityUserRole
                {
                    UserId = context.Users.Where(u => u.UserName == "joueur@isocaedre.ca").First().Id,
                    RoleId = context.Roles.Where(r => r.Name == "Joueurs").First().Id
                },
                new IdentityUserRole
                {
                    UserId = context.Users.Where(u => u.UserName == "maitre@isocaedre.ca").First().Id,
                    RoleId = context.Roles.Where(r => r.Name == "Maîtres").First().Id
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
                    new IdentityRole() { Name = "Modérateurs" },
                    new IdentityRole() { Name = "ExclusionForum" },
                    new IdentityRole() { Name = "Maîtres" },
                    new IdentityRole() { Name = "Joueurs" }
            };
            context.Roles.AddOrUpdate(r => r.Name, roles);
            context.SaveChanges();
        }
    }
}
